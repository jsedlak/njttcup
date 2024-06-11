using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Model;

/// <summary>
/// Represents the complete championship rollup of results into a single leaderboard
/// </summary>
public sealed class Leaderboard : IAggregateRoot
{
    /// <summary>
    /// Gets or Sets the unique identifier of the leaderboard
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or Sets the year this leaderboard represents
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Gets or Sets the list of result identifiers that make up this leaderboard
    /// </summary>
    public IEnumerable<Guid> EventResultIds { get; set; } = [];

    /// <summary>
    /// Gets or Sets the list of category leaderboards that form the master leaderboard
    /// </summary>
    public IEnumerable<CategoryLeaderboard> Categories { get; set; } = [];

    /// <summary>
    /// Gets or Sets whether the leaderboard is deleted and is ready to be permanently removes
    /// </summary>
    public bool IsDeleted { get; set; }
}
