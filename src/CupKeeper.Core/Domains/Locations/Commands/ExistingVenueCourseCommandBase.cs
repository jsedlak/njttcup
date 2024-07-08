namespace CupKeeper.Domains.Locations.Commands;

/// <summary>
/// Represents the base class for commands that require a venue and course
/// </summary>
[GenerateSerializer]
public abstract class ExistingVenueCourseCommandBase
{
    protected ExistingVenueCourseCommandBase(Guid venueId, Guid courseId)
    {
        VenueId = venueId;
        CourseId = courseId;
    }
    
    [Id(0)]
    public Guid VenueId { get; set; }

    [Id(1)]
    public Guid CourseId { get; set; }
}
