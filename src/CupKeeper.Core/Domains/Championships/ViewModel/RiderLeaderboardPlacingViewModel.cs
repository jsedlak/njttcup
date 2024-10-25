namespace CupKeeper.Domains.Championships.ViewModel;

[GenerateSerializer]
public class RiderLeaderboardPlacingViewModel
{
    [Id(0)]
    public Guid Id { get; set; }

    [Id(1)]
    public Guid RiderId { get; set; }

    [Id(2)]
    public string Name { get; set; } = null!;

    [Id(3)]
    public string Team { get; set; } = null!;

    [Id(4)]
    public int RawTotal { get; set; }

    [Id(5)]
    public int Total { get; set; }

    [Id(6)]
    public int[] Points { get; set; } = Array.Empty<int>();
}