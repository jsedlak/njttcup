using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.ScheduledEvents;

[GenerateSerializer]
public sealed class ScheduledEventRestoredEvent : ScheduledEventBaseEvent
{
    public ScheduledEventRestoredEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }
}