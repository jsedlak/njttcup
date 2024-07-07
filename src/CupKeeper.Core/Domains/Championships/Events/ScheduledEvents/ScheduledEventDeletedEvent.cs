using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.ScheduledEvents;

[GenerateSerializer]
public sealed class ScheduledEventDeletedEvent : ScheduledEventBaseEvent
{
    public ScheduledEventDeletedEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }
}