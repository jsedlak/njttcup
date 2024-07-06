namespace CupKeeper.Domains.Championships.Commands;

[GenerateSerializer]
public sealed class RecalculateLeaderboardCommand : ExistingLeaderboardCommandBase
{
    public RecalculateLeaderboardCommand(Guid leaderboardId) 
        : base(leaderboardId)
    {
    }
    
    public int Year { get; set; }
}