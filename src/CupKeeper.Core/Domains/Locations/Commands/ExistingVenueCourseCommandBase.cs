namespace CupKeeper.Domains.Locations.Commands;

/// <summary>
/// Represents the base class for commands that require a venue and course
/// </summary>
public abstract class ExistingVenueCourseCommandBase
{
    public Guid VenueId { get; set; }

    public Guid CourseId { get; set; }
}
