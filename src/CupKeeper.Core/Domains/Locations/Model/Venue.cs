using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Locations.Model;

/// <summary>
/// Represents a location that is used as the basis for scheduling an event
/// </summary>
public sealed class Venue : IAggregateRoot
{
    /// <summary>
    /// Gets or Sets the unique identifier for the venue
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or Sets the name of the venue
    /// </summary>
    public string Name { get; set; } = "Untitled Venue";

    /// <summary>
    /// Gets or Sets the parking address
    /// </summary>
    public Address? ParkingAddress { get; set; } = null!;

    /// <summary>
    /// Gets or Sets the start line address, if different than the parking address
    /// </summary>
    public Address? StartLineAddress { get; set; } = null!;

    /// <summary>
    /// Gets or Sets the list of courses run from this venue
    /// </summary>
    public IEnumerable<Course> Courses { get; set; } = Enumerable.Empty<Course>();
}
