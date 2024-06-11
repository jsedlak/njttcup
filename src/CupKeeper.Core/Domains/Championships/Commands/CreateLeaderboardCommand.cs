namespace CupKeeper.Domains.Championships.Commands;

[GenerateSerializer]
public sealed class CreateLeaderboardCommand
{
    [Id(0)]
    public int Year { get; set; }
}