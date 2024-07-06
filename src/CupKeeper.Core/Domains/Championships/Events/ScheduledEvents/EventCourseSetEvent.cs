using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events;

public sealed class EventCourseSetEvent : AggregateEvent
{
    public EventCourseSetEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }

    public Guid VenueId { get; set; }
    
    public Guid CourseId { get; set; }
}