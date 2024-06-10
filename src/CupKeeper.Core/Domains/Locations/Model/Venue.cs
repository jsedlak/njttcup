using CupKeeper.Cqrs;
using CupKeeper.Domains.Locations.Events;

namespace CupKeeper.Domains.Locations.Model;

/// <summary>
/// Represents a location that is used as the basis for scheduling an event
/// </summary>
public sealed class Venue : IAggregateRoot
{
    #region Venue Events
    public void Apply(VenueCreatedEvent @event)
    {
        Id = @event.AggregateId;
        Name = @event.Name;
        ParkingAddress = @event.ParkingAddress;
    }

    public void Apply(VenueDeletedEvent @event)
    {
        IsDeleted = true;
    }

    public void Apply(VenueNameSetEvent @event)
    {
        Name = @event.Name;
    }

    public void Apply(VenueParkingAddressSetEvent @event)
    {
        ParkingAddress = @event.ParkingAddress;
    }
    #endregion
    
    #region Course Events

    public void Apply(CourseAddedToVenueEvent @event)
    {
        Courses = Courses.Append(new Course
        {
            Id = @event.CourseId,
            Address = @event.Address,
            Description = @event.Description,
            Name = @event.Name,
            Mileage = @event.Mileage,
            RideWithGpsId = @event.RideWithGpsId,
            RouteLink = @event.RouteLink,
            IsDeleted = false
        });
    }

    public void Apply(CourseDeletedFromVenueEvent @event)
    {
        Courses.First(m => m.Id == @event.CourseId).IsDeleted = true;
    }

    public void Apply(CourseMetaDataSetEvent @event)
    {
        var course = Courses.First(m => m.Id == @event.CourseId);
        course.Name = @event.Name;
        course.Description = @event.Description;
    }
    
    public void Apply(CourseRouteDataSetEvent @event)
    {
        var course = Courses.First(m => m.Id == @event.CourseId);
        course.Mileage = @event.Mileage;
        course.RouteLink = @event.RouteLink;
        course.RideWithGpsId = @event.RideWithGpsId;
    }

    public void Apply(CourseAddressSetEvent @event)
    {
        var course = Courses.First(m => m.Id == @event.CourseId);
        course.Address = @event.Address;
    }

    #endregion
    
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
    /// Gets or Sets the list of courses run from this venue
    /// </summary>
    public IEnumerable<Course> Courses { get; set; } = [];
    
    /// <summary>
    /// Gets or Sets whether the venue is deleted and ready for permanent removal pending removal of lingering references
    /// </summary>
    public bool IsDeleted { get; set; }
}
