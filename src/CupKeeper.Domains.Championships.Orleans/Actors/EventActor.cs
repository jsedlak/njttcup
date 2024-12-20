using CupKeeper.Cqrs;
using CupKeeper.Domains.Championships.Commands;
using CupKeeper.Domains.Championships.Commands.EventResults;
using CupKeeper.Domains.Championships.Events.ScheduledEvents;
using CupKeeper.Domains.Championships.Messages;
using CupKeeper.Domains.Championships.Model;
using CupKeeper.Domains.Championships.Model.Parsing;
using CupKeeper.Domains.Championships.ServiceModel;
using Microsoft.Extensions.Logging;
using Orleans.Runtime;
using Orleans.Streams;
using Petl.EventSourcing;

namespace CupKeeper.Domains.Championships.Actors;

public class EventActor : EventSourcedGrain<ScheduledEvent, ScheduledEventBaseEvent>, IEventActor
{
    private readonly ILegacyResultsLoader _legacyResultsLoader;
    private readonly IGrainFactory _grainFactory;
    private readonly IRiderLocatorService _riderLocatorService;
    private readonly ILogger<EventActor> _logger;
    
    private IDisposable? _resultsLoadTimer;
    private IAsyncStream<ScheduledEventBaseEvent>? _eventStream;
    
    public EventActor(IGrainFactory grainFactory, IRiderLocatorService riderLocatorService, ILogger<EventActor> logger, ILegacyResultsLoader legacyResultsLoader)
    {
        _grainFactory = grainFactory;
        _riderLocatorService = riderLocatorService;
        _logger = logger;
        _legacyResultsLoader = legacyResultsLoader;
    }

    public override async Task OnActivateAsync(CancellationToken cancellationToken)
    {
        await base.OnActivateAsync(cancellationToken);
        
        var streamProvider = this.GetStreamProvider("StreamProvider");
        
        var myId = this.GetGrainId().GetGuidKey();
        var streamId = StreamId.Create(ActorConstants.ScheduledEventEventStreamName, myId);
        
        // grab a ref to the stream using the stream id
        _eventStream = streamProvider.GetStream<ScheduledEventBaseEvent>(streamId);
    }

    protected override async Task Raise(ScheduledEventBaseEvent @event)
    {
        await base.Raise(@event);
        await _eventStream!.OnNextAsync(@event);
    }

    protected override async Task Raise(IEnumerable<ScheduledEventBaseEvent> events)
    {
        var eventBatch = events as ScheduledEventBaseEvent[] ?? events.ToArray();
        
        await base.Raise(eventBatch);
        await _eventStream!.OnNextBatchAsync(eventBatch);
    }

    #region Event Management
    public async Task<CommandResult> Create(CreateScheduledEventCommand command)
    {
        await Raise(new ScheduledEventCreatedEvent(this.GetGrainId().GetGuidKey())
        {
            Name = command.Name,
            VenueId = command.VenueId,
            CourseId = command.CourseId,
            ScheduledDate = command.ScheduledDate,
            RegistrationLink = command.RegistrationLink,
            UsacResultsLink = command.UsacResultsLink,
            UsacPermitNumber = command.UsacPermitNumber
        });

        return CommandResult.Success();
    }
    
    public async Task<CommandResult> Delete(DeleteScheduledEventCommand command)
    {
        await Raise(new ScheduledEventDeletedEvent(command.ScheduledEventId));

        return CommandResult.Success();
    }

    public async Task<CommandResult> Undelete(UndeleteScheduledEventCommand command)
    {
        await Raise(new ScheduledEventRestoredEvent(command.ScheduledEventId));
        
        return CommandResult.Success();
    }
    
    public async Task<CommandResult> SetName(SetEventNameCommand command)
    {
        await Raise(new EventNameSetEvent(command.ScheduledEventId)
        {
            Name = command.Name
        });
        
        return CommandResult.Success();
    }
    
    public async Task<CommandResult> SetCourse(SetEventCourseCommand command)
    {
        await Raise(new EventCourseSetEvent(command.ScheduledEventId)
        {
            VenueId = command.VenueId,
            CourseId = command.CourseId
        });
        
        return CommandResult.Success();
    }

    public async Task<CommandResult> SetRegistration(SetEventRegistrationLinkCommand command)
    {
        await Raise(new EventRegistrationLinkSetEvent(command.ScheduledEventId)
        {
            RegistrationLink = command.RegistrationLink
        });
        
        return CommandResult.Success();
    }

    public async Task<CommandResult> SetDates(SetEventDatesCommand command)
    {
        await Raise(new EventDatesSetEvent(command.ScheduledEventId)
        {
            ScheduledDate = command.ScheduledDate,
            ActualDate = command.ActualDate
        });
        
        return CommandResult.Success();
    }

    public async Task<CommandResult> SetUsacData(SetEventUsacDataCommand command)
    {
        await Raise(new EventUsacDataSetEvent(command.ScheduledEventId)
        {
            UsacResultsLink = command.UsacResultsLink,
            UsacPermitNumber = command.UsacPermitNumber
        });
        
        return CommandResult.Success();
    }
    #endregion

    #region Results Management
    public async Task<CommandResult> AddCategory(AddCategoryResultCommand command)
    {
        await Raise(new CategoryResultAddedEvent(command.ScheduledEventId)
        {
             Name = command.Name,
             Order = command.Order
        });
        
        return CommandResult.Success();
    }

    public async Task<CommandResult> RemoveCategory(RemoveCategoryResultCommand command)
    {
        await Raise(new CategoryResultRemovedEvent(command.ScheduledEventId)
        {   
            CategoryResultId = command.CategoryResultId
        });
        
        return CommandResult.Success();
    }

    public async Task<CommandResult> SetCategoryName(SetCategoryResultNameCommand command)
    {
        await Raise(new CategoryResultNameSetEvent(command.ScheduledEventId)
        {
            CategoryResultId = command.CategoryResultId,
            Name = command.Name,
            Order = command.Order
        });
        
        return CommandResult.Success();
    }

    public async Task<CommandResult> AddRider(AddRiderResultCommand command)
    {
        await Raise(new RiderResultAddedEvent(command.ScheduledEventId)
        {
             CategoryResultId = command.CategoryResultId,
             RiderId = command.RiderId,
             Place = command.Position,
             Team = command.Team,
             LicenseNumber = command.LicenseNumber,
             UsacCategory = command.UsacCategory,
             Time = command.Time,
             Points = command.Points
        });
        
        return CommandResult.Success();
    }

    public async Task<CommandResult> MoveRider(MoveRiderResultCommand command)
    {
        await Raise(new RiderResultMovedEvent(command.ScheduledEventId)
        {
            SourceCategoryResultId = command.SourceCategoryResultId,
            RiderResultId = command.RiderResultId,
            TargetCategoryResultId = command.TargetCategoryResultId
        });
        
        return CommandResult.Success();
    }

    public async Task<CommandResult> RemoveRider(RemoveRiderResultCommand command)
    {
        await Raise(new RiderResultRemovedEvent(command.ScheduledEventId)
        {
            CategoryResultId = command.CategoryResultId,
            RiderResultId = command.RiderResultId
        });
        
        return CommandResult.Success();
    }
    #endregion

    #region Publishing
    public async Task<CommandResult> PublishResults(PublishEventResultsCommand command)
    {
        await Raise(new EventResultsPublishedEvent(command.ScheduledEventId));
        await WaitForConfirmation();

        // calculate the year into a grain identifier
        var year = ConfirmedState.ActualDate?.Year ?? ConfirmedState.ScheduledDate?.Year ?? DateTimeOffset.Now.Year;
        var yearAsGrainId = year.ToString().ToGuid();
        
        _logger.LogInformation($"Publishing results and recalculating leaderboard. [Leaderboard ID]=>[{year}, {yearAsGrainId}]");
        
        // recalculate that year's leaderboard
        var proxy = _grainFactory.GetGrain<ILeaderboardActor>(yearAsGrainId);
        await proxy.Recalculate(new RecalculateLeaderboardCommand(yearAsGrainId)
        {
            Year = year
        });
        
        return CommandResult.Success();
    }

    public async Task<CommandResult> UnpublishResults(UnpublishEventResultsCommand command)
    {
        await Raise(new EventResultsUnpublishedEvent(command.ScheduledEventId));
        
        // calculate the year into a grain identifier
        var year = ConfirmedState.ActualDate?.Year ?? ConfirmedState.ScheduledDate?.Year ?? DateTimeOffset.Now.Year;
        var yearAsGrainId = year.ToString().ToGuid();
        
        _logger.LogInformation($"Publishing results and recalculating leaderboard. [Leaderboard ID]=>[{year}, {yearAsGrainId}]");
        
        // recalculate that year's leaderboard
        var proxy = _grainFactory.GetGrain<ILeaderboardActor>(yearAsGrainId);
        await proxy.Recalculate(new RecalculateLeaderboardCommand(yearAsGrainId)
        {
            Year = year
        });
        
        return CommandResult.Success();
    }
    #endregion
    
    #region Ingestion / Parsing

    public async Task<CommandResult> UploadJsonResults(UploadJsonResultsCommand command)
    {
        var results = await _legacyResultsLoader.GetResults(command.Json);

        await HandleParsedResults(results);
        
        return CommandResult.Success();
    }
    
    public async ValueTask<bool> StartResultsLoad()
    {
        if (TentativeState.UsacPermitNumber is null)
        {
            // TODO: Log warning
            return false;
        }

        if (_resultsLoadTimer is not null)
        {
            // TODO: Log warning
            return false;
        }

        var resultsGrainId = TentativeState.UsacPermitNumber!;
        var resultsLoaderGrain = _grainFactory.GetGrain<IEventResultsActor>(resultsGrainId);
        
        var internalResult  = await resultsLoaderGrain.StartLoad(new LoadResultsCommand(resultsGrainId));

        if (!internalResult)
        {
            return false;
        }
        
        _resultsLoadTimer = RegisterTimer(
            CheckResultsLoad,
            new { }, 
            TimeSpan.FromSeconds(5), 
            TimeSpan.FromSeconds(5)
        );

        return true;
    }

    public async ValueTask<bool> CheckResultsLoadFinished()
    {
        if (_resultsLoadTimer is null)
        {
            return true;
        }
        
        var resultsGrainId = TentativeState.UsacPermitNumber!;
        var resultsLoaderGrain = _grainFactory.GetGrain<IEventResultsActor>(resultsGrainId);

        return await resultsLoaderGrain.CheckStatus();
    }

    private async Task CheckResultsLoad(object task)
    {
        var resultsGrainId = TentativeState.UsacPermitNumber!;
        var resultsLoaderGrain = _grainFactory.GetGrain<IEventResultsActor>(resultsGrainId);

        var completed = await resultsLoaderGrain.CheckStatus();

        if (!completed)
        {
            return;
        }
        
        // TODO: Do something with the results
        var results = await resultsLoaderGrain.GetResults();

        if (results is null)
        {
            // TODO: DO SOMETHING
            return;
        }

        await HandleParsedResults(results);

        if (_resultsLoadTimer is not null)
        {
            _resultsLoadTimer.Dispose();
            _resultsLoadTimer = null;
        }
    }

    private async Task HandleParsedResults(ParsedEventResult results)
    {
        var categories = new List<CategoryResult>();
        foreach (var parsedCategory in results.Categories)
        {
            var cat = new CategoryResult
            {
                Name = parsedCategory.Name
            };

            var riderList = new List<RiderResult>();
            
            foreach (var parsedRider in parsedCategory.Results)
            {
                // formalize / search / get the well-known rider
                var rider = await _riderLocatorService.GetAsync(
                    parsedRider.Name, 
                    parsedRider.Team,
                    parsedRider.License
                );

                var isExcluded = !int.TryParse(parsedRider.Place, out int riderPlacing) || riderPlacing <= 0;

                var riderResult = new RiderResult
                {
                    TeamName = rider.TeamName,
                    RiderId = rider.Id,
                    Place = isExcluded ? null : riderPlacing,
                    Points = isExcluded ? 0 : Math.Max(21 - riderPlacing, 0),
                    Time = isExcluded ? null : parsedRider.Time,
                    ExcludeFromPoints = isExcluded,
                    ExclusionReason = isExcluded ? parsedRider.Place : null
                };

                //cat.Riders = [..cat.Riders, riderResult];
                riderList.Add(riderResult);
            }

            cat.Riders = riderList.ToArray();
            
            categories.Add(cat);
        }

        await Raise(new EventResultsLoadedEvent(this.GetGrainId().GetGuidKey())
        {
            Categories = categories
        });
    }
    #endregion
    
    #region Hydration Management
    public async Task ReloadRiderData(Guid riderId)
    {
        await _eventStream!.OnNextAsync(new ReloadRiderRequest(this.GetGrainId().GetGuidKey())
        {
            RiderId = riderId
        });
    }
    #endregion
}