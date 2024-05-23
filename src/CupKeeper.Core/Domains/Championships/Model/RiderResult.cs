/// <summary>
/// Represents a rider's result for a given event
/// </summary>
public sealed class RiderResult
{
    /// <summary>
    /// Gets or Sets the unique identifier for the rider's result
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or Sets the placing
    /// </summary>
    public int Place { get; set; }

    /// <summary>
    /// Gets or Sets the amount of points awarded
    /// </summary>
    public int Points { get; set; }

    /// <summary>
    /// Gets or Sets the rider identifier
    /// </summary>
    public Guid RiderId { get; set; }

    /// <summary>
    /// Gets or Sets the team name for this result
    /// </summary>
    public string? TeamName { get; set; }

    /// <summary>
    /// Gets or Sets the elapsed time the rider took on course
    /// </summary>
    public double Time { get; set; }

    /// <summary>
    /// Gets or Sets whether the result should be excluded from points tallying
    /// </summary>
    public bool ExcludeFromPoints { get; set; }

    /// <summary>
    /// Gets or Sets the reason for excluding the result. E.g. DNS, DNF, DSQ.
    /// </summary>
    public string? ExclusionReason { get; set; }
}
