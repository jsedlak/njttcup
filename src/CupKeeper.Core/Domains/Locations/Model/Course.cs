namespace CupKeeper.Domains.Locations.Model;

/// <summary>
/// Represents a particular route at a venue
/// </summary>
public sealed class Course
{
    /// <summary>
    /// Gets or Sets the unique identifier of the course
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or Sets the name of the course
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or Sets the link to the route for download
    /// </summary>
    public string? RouteLink { get; set; }

    /// <summary>
    /// Gets or Sets the Ride With GPS identifier
    /// </summary>
    public string? RideWithGpsId { get; set; }

    /// <summary>
    /// Gets or Sets the description of the route
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets our Sets the total mileage for the route
    /// </summary>
    public double Mileage { get; set; }

    /// <summary>
    /// Gets or Sets the start address for the course (if different than the venue)
    /// </summary>
    public Address? Address { get; set; }
}
