using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events;

public sealed class LeaderboardDeletedEvent : AggregateEvent
{
    public LeaderboardDeletedEvent(Guid leaderboardId)
        : base(leaderboardId)
    {
        
    }
}