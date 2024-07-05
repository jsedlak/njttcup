using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events;

public sealed class EventDatesSetEvent : AggregateEvent
{
    public EventDatesSetEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }

    public DateTimeOffset? ScheduledDate { get; set; }
    
    public DateTimeOffset? ActualDate { get; set; }
}