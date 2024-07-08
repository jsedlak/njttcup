using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.ScheduledEvents;

[GenerateSerializer]
public abstract class ScheduledEventBaseEvent : AggregateEvent
{
    protected ScheduledEventBaseEvent(Guid scheduledEventId)
        : base(scheduledEventId) {}
}