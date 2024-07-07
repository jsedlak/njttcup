using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.ScheduledEvents;

[GenerateSerializer]
public sealed class EventResultsPublishedEvent : ScheduledEventBaseEvent
{
    public EventResultsPublishedEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }
}