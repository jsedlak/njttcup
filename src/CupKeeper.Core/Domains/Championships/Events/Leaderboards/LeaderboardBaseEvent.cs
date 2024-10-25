using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.Leaderboards;

[GenerateSerializer]
public class LeaderboardBaseEvent : AggregateEvent
{
    public LeaderboardBaseEvent(Guid leaderboardId)
        : base(leaderboardId)
    {
        
    }
}