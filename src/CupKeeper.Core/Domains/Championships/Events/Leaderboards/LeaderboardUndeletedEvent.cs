using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.Leaderboards;

[GenerateSerializer]
public sealed class LeaderboardUndeletedEvent : LeaderboardBaseEvent
{
    public LeaderboardUndeletedEvent(Guid leaderboardId)
        : base(leaderboardId)
    {
        
    }
}