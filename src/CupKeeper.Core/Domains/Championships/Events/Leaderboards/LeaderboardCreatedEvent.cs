using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.Leaderboards;

[GenerateSerializer]
public sealed class LeaderboardCreatedEvent : AggregateEvent
{
    public LeaderboardCreatedEvent(Guid leaderboardId)
        : base(leaderboardId)
    {
        
    }
    
    [Id(0)]
    public int Year { get; set; }

    [Id(1)]
    public IEnumerable<Guid> EventResultIds { get; set; }
}