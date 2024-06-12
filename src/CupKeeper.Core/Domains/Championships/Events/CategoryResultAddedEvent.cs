using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events;

public sealed class CategoryResultAddedEvent : AggregateEvent
{
    public CategoryResultAddedEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }

    public string Name { get; set; }
    public int Order { get; set; }
}