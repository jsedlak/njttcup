namespace CupKeeper.Domains.Championships.Model;

/// <summary>
/// Represents a rider's result for a given event
/// </summary>
[GenerateSerializer]
public sealed class RiderResult
{
    /// <summary>
    /// Gets or Sets the unique identifier for the rider's result
    /// </summary>
    [Id(0)]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or Sets the placing
    /// </summary>
    [Id(1)]
    public int Place { get; set; }

    /// <summary>
    /// Gets or Sets the amount of points awarded
    /// </summary>
    [Id(2)]
    public int Points { get; set; }

    /// <summary>
    /// Gets or Sets the rider identifier
    /// </summary>
    [Id(3)]
    public Guid RiderId { get; set; }

    /// <summary>
    /// Gets or Sets the team name for this result
    /// </summary>
    [Id(4)]
    public string? TeamName { get; set; }

    /// <summary>
    /// Gets or Sets the elapsed time the rider took on course
    /// </summary>
    [Id(5)]
    public double Time { get; set; }

    /// <summary>
    /// Gets or Sets whether the result should be excluded from points tallying
    /// </summary>
    [Id(6)]
    public bool ExcludeFromPoints { get; set; }

    /// <summary>
    /// Gets or Sets the reason for excluding the result. E.g. DNS, DNF, DSQ.
    /// </summary>
    [Id(7)]
    public string? ExclusionReason { get; set; }
}