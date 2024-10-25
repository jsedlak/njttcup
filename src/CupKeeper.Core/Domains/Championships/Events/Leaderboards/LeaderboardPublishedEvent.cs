using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.Leaderboards;

[GenerateSerializer]
public sealed class LeaderboardPublishedEvent : LeaderboardBaseEvent
{
    public LeaderboardPublishedEvent(Guid leaderboardId)
        : base(leaderboardId)
    {
        
    }
}