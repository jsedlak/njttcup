namespace CupKeeper.Domains.Championships.Model;

/// <summary>
/// Represents a single rider within a category and master leaderboard
/// </summary>
[GenerateSerializer]
public sealed class RiderLeaderboardPlacing
{
    /// <summary>
    /// Gets or Sets the unqiue identifier for the rider placing
    /// </summary>
    [Id(0)]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or Sets the referenced rider
    /// </summary>
    [Id(1)]
    public Guid RiderId { get; set; }

    /// <summary>
    /// Gets or Sets the total number of points, taking into account drops
    /// </summary>
    [Id(2)]
    public int Total { get; set; }

    /// <summary>
    /// Gets or Sets the raw total of points
    /// </summary>
    [Id(3)]
    public int RawTotal { get; set; }

    /// <summary>
    /// Gets or Sets the set of points that make up the leaderboard
    /// </summary>
    [Id(4)]
    public int[] Points { get; set; } = Array.Empty<int>();
}
