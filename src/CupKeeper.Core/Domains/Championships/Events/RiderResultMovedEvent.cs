using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events;

public sealed class RiderResultMovedEvent : AggregateEvent
{
    public RiderResultMovedEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }
}