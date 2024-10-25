using CupKeeper.Data;

namespace CupKeeper.Domains.Championships.ViewModel;

[GenerateSerializer]
public class LeaderboardViewModel : IView
{
    [Id(0)] public Guid Id { get; set; }
    
    [Id(1)] public int Year { get; set; }
    
    [Id(2)] public Guid[] Events { get; set; } = Array.Empty<Guid>();

    [Id(3)]
    public CategoryLeaderboardViewModel[] Categories { get; set; } = Array.Empty<CategoryLeaderboardViewModel>();
    
    [Id(4)]
    public bool IsDeleted { get; set; }
    
    [Id(5)]
    public bool IsPublished { get; set; }
}