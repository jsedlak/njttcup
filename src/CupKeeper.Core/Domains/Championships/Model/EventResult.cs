using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Model;

/// <summary>
/// Represents a set of results for a given scheduled event
/// </summary>
public sealed class EventResult
{
    /// <summary>
    /// Gets or Sets the unique identifier of the event result
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or Sets a list of category results
    /// </summary>
    public IEnumerable<CategoryResult> Categories { get; set; } = Enumerable.Empty<CategoryResult>();

    /// <summary>
    /// Gets or Sets a list of change requests against the data
    /// </summary>
    public IEnumerable<ResultChangeRequest> ResultChangeRequests { get; set; } = Enumerable.Empty<ResultChangeRequest>();
}
