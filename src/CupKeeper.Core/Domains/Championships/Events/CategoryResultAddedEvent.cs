using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events;

public sealed class CategoryResultAddedEvent : AggregateEvent
{
    public CategoryResultAddedEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }
}