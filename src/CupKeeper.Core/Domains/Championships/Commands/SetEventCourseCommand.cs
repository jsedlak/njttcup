namespace CupKeeper.Domains.Championships.Commands;

[GenerateSerializer]
public sealed class SetEventCourseCommand : ExistingScheduledEventCommandBase
{
    public SetEventCourseCommand(Guid scheduledEventId) 
        : base(scheduledEventId)
    {
    }
    
    [Id(0)]
    public Guid VenueId { get; set; }

    [Id(1)]
    public Guid CourseId { get; set; }
}
