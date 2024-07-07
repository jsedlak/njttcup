namespace CupKeeper.Domains.Championships.Model;

/// <summary>
/// Represents a set of results for a given scheduled event
/// </summary>
[GenerateSerializer]
public sealed class EventResult
{
    /// <summary>
    /// Gets or Sets the unique identifier of the event result
    /// </summary>
    [Id(0)]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or Sets when the event actually occurred
    /// </summary>
    [Id(1)]
    public DateTimeOffset EventDate { get; set; }

    /// <summary>
    /// Gets or Sets a list of category results
    /// </summary>
    [Id(2)]
    public IEnumerable<CategoryResult> Categories { get; set; } = [];

    /// <summary>
    /// Gets or Sets a list of change requests against the data
    /// </summary>
    [Id(3)]
    public IEnumerable<ResultChangeRequest> ResultChangeRequests { get; set; } = [];
}
