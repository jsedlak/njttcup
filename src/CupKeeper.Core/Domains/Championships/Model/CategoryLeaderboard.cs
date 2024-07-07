namespace CupKeeper.Domains.Championships.Model;

/// <summary>
/// Represents a single grouping of riders, known as a category, as part of a total championship leaderboard
/// </summary>
[GenerateSerializer]
public sealed class CategoryLeaderboard
{
    /// <summary>
    /// Gets or Sets the unique identifier of the category leaderboard
    /// </summary>
    [Id(0)]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or Sets the name of the category
    /// </summary>
    [Id(1)]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or Sets the display order of the category
    /// </summary>
    [Id(2)]
    public int Order { get; set; } = 0;

    /// <summary>
    /// Gets or Sets the rider leaderboard placings
    /// </summary>
    [Id(3)]
    public IEnumerable<RiderLeaderboardPlacing> Riders { get; set; } = [];
}
