using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events;

public sealed class EventNameSetEvent : AggregateEvent
{
    public EventNameSetEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }

    public string Name { get; set; } = null!;
}