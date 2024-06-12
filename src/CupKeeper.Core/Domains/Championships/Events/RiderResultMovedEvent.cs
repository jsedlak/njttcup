using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events;

public sealed class RiderResultMovedEvent : AggregateEvent
{
    public RiderResultMovedEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }
    
    public Guid SourceCategoryResultId { get; set; }

    public Guid RiderResultId { get; set; }

    public Guid TargetCategoryResultId { get; set; }
}