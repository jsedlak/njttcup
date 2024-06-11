using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events;

public sealed class EventScheduledDateSetEvent : AggregateEvent
{
    public EventScheduledDateSetEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }
}