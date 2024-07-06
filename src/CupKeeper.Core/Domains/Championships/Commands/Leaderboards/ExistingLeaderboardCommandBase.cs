namespace CupKeeper.Domains.Championships.Commands;

[GenerateSerializer]
public abstract class ExistingLeaderboardCommandBase
{
    protected ExistingLeaderboardCommandBase(Guid leaderboardId)
    {
        LeaderboardId = leaderboardId;
    }
    
    [Id(0)]
    public Guid LeaderboardId { get; set; }
}