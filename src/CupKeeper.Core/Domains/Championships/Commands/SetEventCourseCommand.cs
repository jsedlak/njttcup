namespace CupKeeper.Domains.Championships.Commands;

public sealed class SetEventCourseCommand : ExistingScheduledEventCommandBase
{
    public Guid VenueId { get; set; }

    public Guid CourseId { get; set; }
}
