using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events;

public sealed class EventUsacDataSetEvent : AggregateEvent
{
    public EventUsacDataSetEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }
}