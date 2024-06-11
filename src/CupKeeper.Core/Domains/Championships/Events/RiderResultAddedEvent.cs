using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events;

public sealed class RiderResultAddedEvent : AggregateEvent
{
    public RiderResultAddedEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }
}