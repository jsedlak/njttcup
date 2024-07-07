using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.ScheduledEvents;

[GenerateSerializer]
public sealed class EventResultsCreatedEvent : AggregateEvent
{
    public EventResultsCreatedEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }
}