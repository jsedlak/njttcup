namespace CupKeeper.Domains.Championships.Model;

/// <summary>
/// Represents a request to change a result
/// </summary>
[GenerateSerializer]
public sealed class ResultChangeRequest
{
    /// <summary>
    /// Gets or Sets the unique identifier of the request
    /// </summary>
    [Id(0)]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or Sets the source category identifier
    /// </summary>
    [Id(1)]
    public Guid SourceCategoryId { get; set; }

    /// <summary>
    /// Gets or Sets the source rider result identifier
    /// </summary>
    [Id(2)]
    public Guid SourceRiderResultId { get; set; }

    /// <summary>
    /// Gets or Sets the target category identifier where the rider should be moved
    /// </summary>
    [Id(3)]
    public Guid? TargetCategoryId { get; set; }

    /// <summary>
    /// Gets or Sets the new rider identifier who should replace the existing rider
    /// </summary>
    [Id(4)]
    public Guid? NewRiderId { get; set; }

    /// <summary>
    /// Gets or Sets the new elapsed time for the result
    /// </summary>
    [Id(5)]
    public double? NewTime { get; set; }
}