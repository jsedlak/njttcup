namespace CupKeeper.Domains.Championships.ViewModel;

[GenerateSerializer]
public class CategoryLeaderboardViewModel
{
    [Id(0)] public Guid Id { get; set; }

    [Id(1)] public string Name { get; set; } = default!;

    [Id(2)] public int Order { get; set; }

    [Id(3)]
    public RiderLeaderboardPlacingViewModel[] Riders { get; set; } = Array.Empty<RiderLeaderboardPlacingViewModel>();
}