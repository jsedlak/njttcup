namespace CupKeeper.Domains.Championships.Commands;

[GenerateSerializer]
public sealed class RecalculateLeaderboardCommand : ExistingLeaderboardCommandBase
{
    public RecalculateLeaderboardCommand(Guid leaderboardId) 
        : base(leaderboardId)
    {
    }

    [Id(0)]
    public int Year { get; set; }
}