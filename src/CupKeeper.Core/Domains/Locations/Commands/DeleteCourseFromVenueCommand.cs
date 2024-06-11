namespace CupKeeper.Domains.Locations.Commands;

[GenerateSerializer]
public sealed class DeleteCourseFromVenueCommand : ExistingVenueCourseCommandBase
{
    public DeleteCourseFromVenueCommand(Guid venueId, Guid courseId) 
        : base(venueId, courseId)
    {
    }
}