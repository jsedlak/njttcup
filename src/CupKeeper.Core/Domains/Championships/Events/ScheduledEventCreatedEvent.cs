using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events;

public sealed class ScheduledEventCreatedEvent : AggregateEvent
{
    public ScheduledEventCreatedEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }
}