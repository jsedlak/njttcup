namespace CupKeeper.Domains.Championships.Commands;

[GenerateSerializer]
public sealed class DeleteLeaderboardCommand : ExistingLeaderboardCommandBase
{
    public DeleteLeaderboardCommand(Guid leaderboardId) 
        : base(leaderboardId)
    {
    }
}