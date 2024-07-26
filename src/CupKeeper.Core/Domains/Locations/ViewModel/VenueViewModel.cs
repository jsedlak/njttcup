using CupKeeper.Data;
using CupKeeper.Domains.Locations.Model;

namespace CupKeeper.Domains.Locations.ViewModel;

[GenerateSerializer]
public class VenueViewModel : IView
{
    /// <summary>
    /// Gets or Sets the unique identifier for the venue
    /// </summary>
    [Id(0)]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or Sets the name of the venue
    /// </summary>
    [Id(1)]
    public string Name { get; set; } = "Untitled Venue";

    /// <summary>
    /// Gets or Sets the parking address
    /// </summary>
    [Id(2)]
    public Address? ParkingAddress { get; set; } = null!;

    /// <summary>
    /// Gets or Sets the list of courses run from this venue
    /// </summary>
    [Id(3)]
    public IEnumerable<CourseViewModel> Courses { get; set; } = [];
    
    /// <summary>
    /// Gets or Sets whether the venue is deleted and ready for permanent removal pending removal of lingering references
    /// </summary>
    [Id(4)]
    public bool IsDeleted { get; set; }
    
}