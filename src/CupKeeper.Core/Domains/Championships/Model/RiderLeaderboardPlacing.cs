namespace CupKeeper.Domains.Championships.Model;

/// <summary>
/// Represents a single rider within a category and master leaderboard
/// </summary>
public sealed class RiderLeaderboardPlacing
{
    /// <summary>
    /// Gets or Sets the unqiue identifier for the rider placing
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or Sets the referenced rider
    /// </summary>
    public Guid RiderId { get; set; }

    /// <summary>
    /// Gets or Sets the total number of points, taking into account drops
    /// </summary>
    public int Total { get; set; }

    /// <summary>
    /// Gets or Sets the raw total of points
    /// </summary>
    public int RawTotal { get; set; }

    /// <summary>
    /// Gets or Sets the set of points that make up the leaderboard
    /// </summary>
    public IEnumerable<int> Points { get; set; } = Enumerable.Empty<int>();
}
