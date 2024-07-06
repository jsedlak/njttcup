using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events;

public sealed class LeaderboardRecalculatedEvent : AggregateEvent
{
    public LeaderboardRecalculatedEvent(Guid leaderboardId)
        : base(leaderboardId)
    {
        
    }
    
    public int Year { get; set; }
}