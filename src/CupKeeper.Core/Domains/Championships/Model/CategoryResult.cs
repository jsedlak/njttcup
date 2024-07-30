namespace CupKeeper.Domains.Championships.Model;

/// <summary>
/// Represents a group of riders competing against each other and their results for a particular event
/// </summary>
[GenerateSerializer]
public sealed class CategoryResult
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
    public IEnumerable<RiderResult> Riders { get; set; } = [];
}