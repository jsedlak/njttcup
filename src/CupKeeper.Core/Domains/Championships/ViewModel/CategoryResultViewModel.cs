namespace CupKeeper.Domains.Championships.ViewModel;

[GenerateSerializer]
public sealed class CategoryResultViewModel
{
    /// <summary>
    /// Gets or Sets the unique identifier for this category
    /// </summary>
    [Id(0)]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or Sets the display order of this category
    /// </summary>
    [Id(1)]
    public int Order { get; set; } = 0;

    /// <summary>
    /// Gets or Sets the name of the category
    /// </summary>
    [Id(2)] 
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or Sets the set of rider results for the event
    /// </summary>
    [Id(3)]
    public RiderResultViewModel[] Riders { get; set; } = [];
    
    /// <summary>
    /// Gets or Sets the set of riders excluded from receiving points
    /// </summary>
    [Id(4)]
    public RiderResultViewModel[] ExcludedRiders { get; set; } = [];
}