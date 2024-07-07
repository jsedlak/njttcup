using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.ScheduledEvents;

[GenerateSerializer]
public sealed class EventCourseSetEvent : AggregateEvent
{
    public EventCourseSetEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }

    [Id(0)]
    public Guid VenueId { get; set; }
    
    [Id(1)]
    public Guid CourseId { get; set; }
}