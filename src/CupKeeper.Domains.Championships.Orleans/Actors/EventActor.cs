using CupKeeper.Cqrs;
using CupKeeper.Domains.Championships.Commands;
using CupKeeper.Domains.Championships.Commands.EventResults;
using CupKeeper.Domains.Championships.Events;
using CupKeeper.Domains.Championships.Model;
using Microsoft.Extensions.DependencyInjection;
using Orleans.Runtime;
using Petl.EventSourcing;

namespace CupKeeper.Domains.Championships.Actors;

public class EventActor : EventSourcedGrain<ScheduledEvent, AggregateEvent>, IEventActor
{
    private readonly IGrainFactory _grainFactory;
    private IDisposable? _resultsLoadTimer;
    
    public EventActor(IGrainFactory grainFactory)
    {
        _grainFactory = grainFactory;
    }
    
    public Task<CommandResult> Create(CreateScheduledEventCommand command)
    {
        Raise(new ScheduledEventCreatedEvent(this.GetGrainId().GetGuidKey())
        {
            Name = command.Name,
            VenueId = command.VenueId,
            CourseId = command.CourseId,
            ScheduledDate = command.ScheduledDate,
            RegistrationLink = command.RegistrationLink,
            UsacResultsLink = command.UsacResultsLink,
            UsacPermitNubmer = command.UsacPermitNumber
        });

        return Task.FromResult(
            CommandResult.Success()
        );
    }

    public Task<CommandResult> Delete(DeleteScheduledEventCommand command)
    {
        Raise(new ScheduledEventDeletedEvent(command.ScheduledEventId));

        return Task.FromResult(CommandResult.Success());
    }

    public Task<CommandResult> SetName(SetEventNameCommand command)
    {
        Raise(new EventNameSetEvent(command.ScheduledEventId)
        {
            Name = command.Name
        });
        
        return Task.FromResult(CommandResult.Success());
    }

    public Task<CommandResult> SetCourse(SetEventCourseCommand command)
    {
        Raise(new EventCourseSetEvent(command.ScheduledEventId)
        {
            VenueId = command.VenueId,
            CourseId = command.CourseId
        });
        
        return Task.FromResult(CommandResult.Success());
    }

    public Task<CommandResult> SetRegistration(SetEventRegistrationLinkCommand command)
    {
        Raise(new EventRegistrationLinkSetEvent(command.ScheduledEventId)
        {
            RegistrationLink = command.RegistrationLink
        });
        
        return Task.FromResult(CommandResult.Success());
    }

    public Task<CommandResult> SetDates(SetEventDatesCommand command)
    {
        Raise(new EventDatesSetEvent(command.ScheduledEventId)
        {
            ScheduledDate = command.ScheduledDate,
            ActualDate = command.ActualDate
        });
        
        return Task.FromResult(CommandResult.Success());
    }

    public Task<CommandResult> SetUsacData(SetEventUsacDataCommand command)
    {
        Raise(new EventUsacDataSetEvent(command.ScheduledEventId)
        {
            UsacResultsLink = command.UsacResultsLink,
            UsacPermitNumber = command.UsacPermitNumber
        });
        
        return Task.FromResult(CommandResult.Success());
    }

    public Task<CommandResult> AddCategory(AddCategoryResultCommand command)
    {
        Raise(new CategoryResultAddedEvent(command.ScheduledEventId)
        {
             Name = command.Name,
             Order = command.Order
        });
        
        return Task.FromResult(CommandResult.Success());
    }

    public Task<CommandResult> RemoveCategory(RemoveCategoryResultCommand command)
    {
        Raise(new CategoryResultRemovedEvent(command.ScheduledEventId)
        {   
            CategoryResultId = command.CategoryResultId
        });
        
        return Task.FromResult(CommandResult.Success());
    }

    public Task<CommandResult> SetCategoryName(SetCategoryResultNameCommand command)
    {
        Raise(new CategoryResultNameSetEvent(command.ScheduledEventId)
        {
            CategoryResultId = command.CategoryResultId,
            Name = command.Name
        });
        return Task.FromResult(CommandResult.Success());
    }

    public Task<CommandResult> AddRider(AddRiderResultCommand command)
    {
        Raise(new RiderResultAddedEvent(command.ScheduledEventId)
        {
             CategoryResultId = command.CategoryResultId,
             RiderId = command.RiderId,
             Position = command.Position,
             Team = command.Team,
             LicenseNumber = command.LicenseNumber,
             UsacCategory = command.UsacCategory,
             Time = command.Time,
             Points = command.Points
        });
        
        return Task.FromResult(CommandResult.Success());
    }

    public Task<CommandResult> MoveRider(MoveRiderResultCommand command)
    {
        Raise(new RiderResultMovedEvent(command.ScheduledEventId)
        {
            SourceCategoryResultId = command.SourceCategoryResultId,
            RiderResultId = command.RiderResultId,
            TargetCategoryResultId = command.TargetCategoryResultId
        });
        
        return Task.FromResult(CommandResult.Success());
    }

    public Task<CommandResult> RemoveRider(RemoveRiderResultCommand command)
    {
        Raise(new RiderResultRemovedEvent(command.ScheduledEventId)
        {
            CategoryResultId = command.CategoryResultId,
            RiderResultId = command.RiderResultId
        });
        
        return Task.FromResult(CommandResult.Success());
    }

    public async Task<CommandResult> PublishResults(PublishEventResultsCommand command)
    {
        Raise(new EventResultsPublishedEvent(command.ScheduledEventId));

        await WaitForConfirmation();

        // calculate the year into a grain identifier
        var year = State.ActualDate?.Year ?? State.ScheduledDate?.Year ?? DateTimeOffset.Now.Year;
        var yearAsGrainId = year.ToString().ToGuid();
        
        // recalculate that year's leaderboard
        var proxy = _grainFactory.GetGrain<ILeaderboardActor>(yearAsGrainId);
        await proxy.Recalculate(new RecalculateLeaderboardCommand(yearAsGrainId)
        {
            Year = year
        });
        
        return CommandResult.Success();
    }

    public async ValueTask<bool> StartResultsLoad()
    {
        if (State.UsacPermitNumber is null)
        {
            // TODO: Log warning
            return false;
        }

        if (_resultsLoadTimer is not null)
        {
            // TODO: Log warning
            return false;
        }

        var resultsGrainId = State.UsacPermitNumber!;
        var resultsLoaderGrain = _grainFactory.GetGrain<IEventResultsActor>(resultsGrainId);
        
        var internalResult  = await resultsLoaderGrain.StartLoad(new LoadResultsCommand());

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

    private async Task CheckResultsLoad(object task)
    {
        var resultsGrainId = State.UsacPermitNumber!;
        var resultsLoaderGrain = _grainFactory.GetGrain<IEventResultsActor>(resultsGrainId);

        var completed = await resultsLoaderGrain.CheckStatus();

        if (!completed)
        {
            return;
        }
        
        // TODO: Do something with the results
        var results = await resultsLoaderGrain.GetResults();

        if (_resultsLoadTimer is not null)
        {
            _resultsLoadTimer.Dispose();
            _resultsLoadTimer = null;
        }
    }
}