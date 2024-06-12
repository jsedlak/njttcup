using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events;

public sealed class CategoryResultRemovedEvent : AggregateEvent
{
    public CategoryResultRemovedEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }

    public Guid CategoryResultId { get; set; }
}