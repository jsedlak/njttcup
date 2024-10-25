using CupKeeper.Cqrs;
using CupKeeper.Domains.Championships.Model;

namespace CupKeeper.Domains.Championships.Events.Leaderboards;

[GenerateSerializer]
public sealed class LeaderboardRecalculatedEvent : LeaderboardBaseEvent
{
    public LeaderboardRecalculatedEvent(Guid leaderboardId)
        : base(leaderboardId)
    {
    }

    [Id(0)] public int Year { get; set; }

    [Id(1)] public Guid[] EventResultIds { get; set; } = Array.Empty<Guid>();

    [Id(2)] public CategoryLeaderboard[] Categories { get; set; } = Array.Empty<CategoryLeaderboard>();
}