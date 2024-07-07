using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.Leaderboards;

[GenerateSerializer]
public sealed class LeaderboardRecalculatedEvent : AggregateEvent
{
    public LeaderboardRecalculatedEvent(Guid leaderboardId)
        : base(leaderboardId)
    {
        
    }
    
    [Id(0)]
    public int Year { get; set; }
}