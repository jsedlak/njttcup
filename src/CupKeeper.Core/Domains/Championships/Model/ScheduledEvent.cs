using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Model;

/// <summary>
/// Represents a scheduled event on the race calendar for a given year
/// </summary>
public sealed class ScheduledEvent : IAggregateRoot
{
    /// <summary>
    /// Gets or Sets the unique identifier for the scheduled event
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or Sets the referenced venue identifier
    /// </summary>
    public Guid VenueId { get; set; }

    /// <summary>
    /// Gets or Sets the particular course's identifier within the venue
    /// </summary>
    public Guid CourseId { get; set; }

    /// <summary>
    /// Gets or Sets the name of the event
    /// </summary>
    public string Name { get; set; } = null!;
    
    /// <summary>
    /// Gets or Sets when the event is scheduled to occur
    /// </summary>
    public DateTimeOffset? ScheduledDate { get; set; }

    /// <summary>
    /// Gets or Sets when the event actually occurred
    /// </summary>
    public DateTimeOffset? ActualDate { get; set; }

    /// <summary>
    /// Gets or Sets the link to register for the event
    /// </summary>
    public string? RegistrationLink { get; set; }

    /// <summary>
    /// Gets or Sets the link to the results
    /// </summary>
    public string? UsacResultsLink { get; set; }

    /// <summary>
    /// Gets or Sets the USA Cycling permit number
    /// </summary>
    public string? UsacPermitNumber { get; set; }

    /// <summary>
    /// Gets or Sets the set of results for the event
    /// </summary>
    public EventResult? Results { get; set; }
    
    /// <summary>
    /// Gets or Sets whether the event is deleted and is ready to be permanently removes
    /// </summary>
    public bool IsDeleted { get; set; }
}
