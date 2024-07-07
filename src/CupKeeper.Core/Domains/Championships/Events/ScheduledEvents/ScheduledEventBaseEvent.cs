using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.ScheduledEvents;

public abstract class ScheduledEventBaseEvent : AggregateEvent
{
    protected ScheduledEventBaseEvent(Guid scheduledEventId)
        : base(scheduledEventId) {}
}