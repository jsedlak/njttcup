using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events;

public sealed class EventResultsCreatedEvent : AggregateEvent
{
    public EventResultsCreatedEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }
}