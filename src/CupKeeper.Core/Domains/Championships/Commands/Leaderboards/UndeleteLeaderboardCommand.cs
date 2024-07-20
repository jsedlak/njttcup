namespace CupKeeper.Domains.Championships.Commands;

[GenerateSerializer]
public sealed class UndeleteLeaderboardCommand : ExistingLeaderboardCommandBase
{
    public UndeleteLeaderboardCommand(Guid leaderboardId) 
        : base(leaderboardId)
    {
    }
}