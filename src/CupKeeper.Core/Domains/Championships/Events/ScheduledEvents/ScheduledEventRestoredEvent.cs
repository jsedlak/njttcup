using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.ScheduledEvents;

[GenerateSerializer]
public sealed class ScheduledEventRestoredEvent : AggregateEvent
{
    public ScheduledEventRestoredEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }
}