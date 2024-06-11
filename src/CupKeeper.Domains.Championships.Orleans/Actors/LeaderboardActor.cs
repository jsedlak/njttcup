using CupKeeper.Cqrs;
using CupKeeper.Domains.Championships.Commands;
using CupKeeper.Domains.Championships.Model;
using Petl.EventSourcing;

namespace CupKeeper.Domains.Championships.Actors;

public class LeaderboardActor : EventSourcedGrain<Leaderboard, AggregateEvent>, ILeaderboardActor
{
    public Task<CommandResult> Create(CreateLeaderboardCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<CommandResult> Delete(DeleteLeaderboardCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<CommandResult> Recalculate(RecalculateLeaderboardCommand command)
    {
        throw new NotImplementedException();
    }
}