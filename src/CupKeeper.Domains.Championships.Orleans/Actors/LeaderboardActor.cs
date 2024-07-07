using CupKeeper.Cqrs;
using CupKeeper.Domains.Championships.Commands;
using CupKeeper.Domains.Championships.Events.Leaderboards;
using CupKeeper.Domains.Championships.Model;
using Microsoft.Extensions.Logging;
using Orleans.Runtime;
using Petl.EventSourcing;

namespace CupKeeper.Domains.Championships.Actors;

public class LeaderboardActor : EventSourcedGrain<Leaderboard, AggregateEvent>, ILeaderboardActor
{
    private readonly ILogger<LeaderboardActor> _logger;
    
    public LeaderboardActor(ILogger<LeaderboardActor> logger)
    {
        _logger = logger;
    }
    
    public Task<CommandResult> Create(CreateLeaderboardCommand command)
    {
        Raise(new LeaderboardCreatedEvent(this.GetGrainId().GetGuidKey())
        {
            Year = command.Year
        });
        
        return Task.FromResult(CommandResult.Success());
    }

    public Task<CommandResult> Delete(DeleteLeaderboardCommand command)
    {
        Raise(new LeaderboardDeletedEvent(command.LeaderboardId));
        
        return Task.FromResult(CommandResult.Success());
    }

    public Task<CommandResult> Recalculate(RecalculateLeaderboardCommand command)
    {
        _logger.LogInformation($"Initiating recalculation of the leaderboard for year {command.Year}");
        
        Raise(new LeaderboardRecalculatedEvent(command.LeaderboardId)
        {
            Year = command.Year
        });
        
        return Task.FromResult(CommandResult.Success());
    }
}