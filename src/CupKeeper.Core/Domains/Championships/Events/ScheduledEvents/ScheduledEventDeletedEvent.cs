using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.ScheduledEvents;

[GenerateSerializer]
public sealed class ScheduledEventDeletedEvent : AggregateEvent
{
    public ScheduledEventDeletedEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }
}