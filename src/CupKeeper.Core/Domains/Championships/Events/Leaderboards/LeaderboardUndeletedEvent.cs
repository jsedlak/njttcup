using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.Leaderboards;

[GenerateSerializer]
public sealed class LeaderboardUndeletedEvent : AggregateEvent
{
    public LeaderboardUndeletedEvent(Guid leaderboardId)
        : base(leaderboardId)
    {
        
    }
}