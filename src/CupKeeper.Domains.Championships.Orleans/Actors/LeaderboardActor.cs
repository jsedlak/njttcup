using CupKeeper.Cqrs;
using CupKeeper.Domains.Championships.Commands;
using CupKeeper.Domains.Championships.Events;
using CupKeeper.Domains.Championships.Model;
using Orleans.Runtime;
using Petl.EventSourcing;

namespace CupKeeper.Domains.Championships.Actors;

public class LeaderboardActor : EventSourcedGrain<Leaderboard, AggregateEvent>, ILeaderboardActor
{
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
        Raise(new LeaderboardRecalculatedEvent(command.LeaderboardId)
        {
            Year = command.Year
        });
        
        return Task.FromResult(CommandResult.Success());
    }
}