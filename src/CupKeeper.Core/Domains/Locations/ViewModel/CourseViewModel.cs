using CupKeeper.Domains.Locations.Model;

namespace CupKeeper.Domains.Locations.ViewModel;

[GenerateSerializer]
public sealed class CourseViewModel
{
    /// <summary>
    /// Gets or Sets the unique identifier of the course
    /// </summary>
    [Id(0)]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or Sets the name of the course
    /// </summary>
    [Id(1)]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or Sets the link to the route for download
    /// </summary>
    [Id(2)]
    public string? RouteLink { get; set; }

    /// <summary>
    /// Gets or Sets the Ride With GPS identifier
    /// </summary>
    [Id(3)]
    public string? RideWithGpsId { get; set; }

    /// <summary>
    /// Gets or Sets the description of the route
    /// </summary>
    [Id(4)]
    public string? Description { get; set; }

    /// <summary>
    /// Gets our Sets the total mileage for the route
    /// </summary>
    [Id(5)]
    public double Mileage { get; set; }

    /// <summary>
    /// Gets or Sets the start address for the course (if different than the venue)
    /// </summary>
    [Id(6)]
    public Address? Address { get; set; }
    
    /// <summary>
    /// Gets or Sets whether this course is deleted and ready for permanent removal
    /// </summary>
    [Id(7)]
    public bool IsDeleted { get; set; }
}