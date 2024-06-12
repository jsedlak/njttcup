using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events;

public sealed class LeaderboardCreatedEvent : AggregateEvent
{
    public LeaderboardCreatedEvent(Guid leaderboardId)
        : base(leaderboardId)
    {
        
    }
    
    public int Year { get; set; }
}