using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.Leaderboards;

[GenerateSerializer]
public sealed class LeaderboardDeletedEvent : LeaderboardBaseEvent
{
    public LeaderboardDeletedEvent(Guid leaderboardId)
        : base(leaderboardId)
    {
        
    }
}