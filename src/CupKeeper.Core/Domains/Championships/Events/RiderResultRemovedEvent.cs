using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events;

public sealed class RiderResultRemovedEvent : AggregateEvent
{
    public RiderResultRemovedEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }

    public Guid RiderResultId { get; set; }
    
    public Guid CategoryResultId { get; set; }
}