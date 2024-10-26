using CupKeeper.Cqrs;
using CupKeeper.Domains.Championships.Commands;
using CupKeeper.Domains.Championships.Events.Leaderboards;
using CupKeeper.Domains.Championships.Events.ScheduledEvents;
using CupKeeper.Domains.Championships.Model;
using CupKeeper.Domains.Championships.ServiceModel;
using CupKeeper.Extensions;
using Microsoft.Extensions.Logging;
using Orleans.Runtime;
using Orleans.Streams;
using Petl.EventSourcing;

namespace CupKeeper.Domains.Championships.Actors;

public class LeaderboardActor : EventSourcedGrain<Leaderboard, LeaderboardBaseEvent>, ILeaderboardActor
{
    private readonly IEventViewRepository _eventViewRepository;
    private IAsyncStream<LeaderboardBaseEvent>? _eventStream;
    private readonly ILogger<LeaderboardActor> _logger;
    
    public LeaderboardActor(IEventViewRepository eventViewRepository, ILogger<LeaderboardActor> logger)
    {
        _logger = logger;
        _eventViewRepository = eventViewRepository;
    }
    
    #region Event Management
    public override async Task OnActivateAsync(CancellationToken cancellationToken)
    {
        await base.OnActivateAsync(cancellationToken);
        
        var streamProvider = this.GetStreamProvider("StreamProvider");
        
        var myId = this.GetGrainId().GetGuidKey();
        var streamId = StreamId.Create(ActorConstants.LeaderboardEventStreamName, myId);
        
        // grab a ref to the stream using the stream id
        _eventStream = streamProvider.GetStream<LeaderboardBaseEvent>(streamId);
    }

    protected override async Task Raise(LeaderboardBaseEvent @event)
    {
        await base.Raise(@event);
        await _eventStream!.OnNextAsync(@event);
    }

    protected override async Task Raise(IEnumerable<LeaderboardBaseEvent> events)
    {
        var eventBatch = events as LeaderboardBaseEvent[] ?? events.ToArray();
        
        await base.Raise(eventBatch);
        await _eventStream!.OnNextBatchAsync(eventBatch);
    }
    #endregion
    
    public async Task<CommandResult> Create(CreateLeaderboardCommand command)
    {
        await Raise(new LeaderboardCreatedEvent(this.GetGrainId().GetGuidKey())
        {
            Year = command.Year
        });
        
        return CommandResult.Success();
    }

    public async Task<CommandResult> Delete(DeleteLeaderboardCommand command)
    {
        await Raise(new LeaderboardDeletedEvent(command.LeaderboardId));
        
        return CommandResult.Success();
    }

    public async Task<CommandResult> Undelete(UndeleteLeaderboardCommand command)
    {  
        await Raise(new LeaderboardUndeletedEvent(command.LeaderboardId));

        return CommandResult.Success();
    }

    public async Task<CommandResult> Recalculate(RecalculateLeaderboardCommand command)
    {
        _logger.LogInformation($"Initiating recalculation of the leaderboard for year {command.Year}");
        
        // TODO: Move this to a long execution method
        var publishedEvents = (await _eventViewRepository.QueryAsync())
            .Where(m => m.ChampionshipYear == command.Year && m.IsPublished)
            .OrderBy(m => m.ActualDate);
        
        _logger.LogInformation($"Found {publishedEvents.Count()} events for year {command.Year}");

        var eventCount = 0;
        var categoryLeaderboards = new List<CategoryLeaderboard>();
        var riderRefShortcut = new List<RiderLeaderboardPlacing>();

        // load up every riders' points for every result
        foreach (var eventResult in publishedEvents)
        {
            foreach (var categoryResult in eventResult.Results)
            {
                // create/get the category
                var categoryLeaderboard = categoryLeaderboards.GetOrSet(categoryResult.Name);
                
                foreach (var riderResult in categoryResult.Riders)
                {
                    // create/get the rider
                    var riderLeaderboard = categoryLeaderboard.GetOrSet(riderResult.RiderId);
                    riderRefShortcut.Add(riderLeaderboard);

                    // add zeros to bring this rider up to the current event count
                    // e.g. if it's the 5th event and the rider has 2 scores, 5-1-2=2 zeros will be added (#-#-0-0-CURRENT)
                    var missingCount = eventCount - 1 - riderLeaderboard.Points.Length;
                    if (missingCount > 0)
                    {
                        riderLeaderboard.Points = riderLeaderboard.Points.Union(
                            Enumerable.Range(1, missingCount).Select(x => 0)
                        ).ToArray();
                    }
                    
                    // add this result's points, defaulting to 0 if there were none awarded
                    riderLeaderboard.Points = riderLeaderboard.Points
                        .Append(riderResult.Points.GetValueOrDefault(0))
                        .ToArray();
                }
            }

            eventCount++;
        }

        // now we calculate the drops
        foreach (var riderLeaderboard in riderRefShortcut)
        {
            _logger.LogInformation($"Rider {riderLeaderboard.RiderId} has {riderLeaderboard.Points.Length} races of {eventCount} total.");
            
            // ensure the rider completes the total number of events
            // attributing 0 to any event missing at the end
            var riderPointsCount = riderLeaderboard.Points.Length;
            if (riderPointsCount < eventCount)
            {
                riderLeaderboard.Points = riderLeaderboard.Points.Union(
                    Enumerable.Range(1, eventCount - riderPointsCount).Select(x => 0)
                ).ToArray();
            }
            
            // if we've got less than 7 races, there are no drops
            if (eventCount < 7)
            {
                riderLeaderboard.RawTotal = riderLeaderboard.Points.Sum();
                riderLeaderboard.Total = riderLeaderboard.Points.Sum();
            }
            // if we're less than 10, we will have one drop
            else if (eventCount < 10)
            {
                // build the total by subtracting the two lowest scores
                var lowest = riderLeaderboard.Points.Min();
                riderLeaderboard.Total = riderLeaderboard.Points.Sum() - lowest;

                riderLeaderboard.RawTotal = Math.Max(riderLeaderboard.Points.Sum(), 0);
                riderLeaderboard.Total = Math.Max(riderLeaderboard.Total, 0);
            }
            // otherwise, we will have two drops
            else
            {
                // build the total by subtracting the two lowest scores
                var (lowest, secondLowest) = riderLeaderboard.Points.Min2();
                riderLeaderboard.Total = riderLeaderboard.Points.Sum() - lowest - secondLowest;

                riderLeaderboard.RawTotal = Math.Max(riderLeaderboard.Points.Sum(), 0);
                riderLeaderboard.Total = Math.Max(riderLeaderboard.Total, 0);
            }
        }
        
        _logger.LogInformation($"Raising recalc event for Leaderboard: {command.LeaderboardId}");
        
        await Raise(new LeaderboardRecalculatedEvent(command.LeaderboardId)
        {
            Year = command.Year,
            Categories = categoryLeaderboards.ToArray(),
            EventResultIds = publishedEvents.Select(m => m.Id).ToArray()
        });
        
        return CommandResult.Success();
    }

    public async Task<CommandResult> Publish(PublishLeaderboardCommand command)
    {
        await Raise(new LeaderboardPublishedEvent(this.GetGrainId().GetGuidKey()));

        return CommandResult.Success();
    }

    public async Task<CommandResult> Unpublish(UnpublishLeaderboardCommand command)
    {
        await Raise(new LeaderboardUnpublishedEvent(this.GetGrainId().GetGuidKey()));

        return CommandResult.Success();
    }
}