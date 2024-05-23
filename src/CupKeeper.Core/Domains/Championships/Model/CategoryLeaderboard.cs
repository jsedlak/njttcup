namespace CupKeeper.Domains.Championships.Model;

/// <summary>
/// Represents a single grouping of riders, known as a category, as part of a total championship leaderboard
/// </summary>
public sealed class CategoryLeaderboard
{
    /// <summary>
    /// Gets or Sets the unique identifier of the category leaderboard
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or Sets the name of the category
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or Sets the display order of the category
    /// </summary>
    public int Order { get; set; } = 0;

    /// <summary>
    /// Gets or Sets the rider leaderboard placings
    /// </summary>
    public IEnumerable<RiderLeaderboardPlacing> Riders { get; set; } = Enumerable.Empty<RiderLeaderboardPlacing>();
}
