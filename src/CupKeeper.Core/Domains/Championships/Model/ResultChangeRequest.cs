/// <summary>
/// Represents a request to change a result
/// </summary>
public sealed class ResultChangeRequest
{
    /// <summary>
    /// Gets or Sets the unique identifier of the request
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or Sets the source category identifier
    /// </summary>
    public Guid SourceCategoryId { get; set; }

    /// <summary>
    /// Gets or Sets the source rider result identifier
    /// </summary>
    public Guid SourceRiderResultId { get; set; }

    /// <summary>
    /// Gets or Sets the target category identifier where the rider should be moved
    /// </summary>
    public Guid? TargetCategoryId { get; set; }

    /// <summary>
    /// Gets or Sets the new rider identifier who should replace the existing rider
    /// </summary>
    public Guid? NewRiderId { get; set; }

    /// <summary>
    /// Gets or Sets the new elapsed time for the result
    /// </summary>
    public double? NewTime { get; set; }
}