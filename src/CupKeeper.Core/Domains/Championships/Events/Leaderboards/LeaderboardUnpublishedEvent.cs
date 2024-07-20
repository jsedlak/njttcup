using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.Leaderboards;

[GenerateSerializer]
public sealed class LeaderboardUnpublishedEvent : AggregateEvent
{
    public LeaderboardUnpublishedEvent(Guid leaderboardId)
        : base(leaderboardId)
    {
        
    }
}