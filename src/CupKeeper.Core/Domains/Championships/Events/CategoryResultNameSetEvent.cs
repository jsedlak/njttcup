using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events;

public sealed class CategoryResultNameSetEvent : AggregateEvent
{
    public CategoryResultNameSetEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }

    public Guid CategoryResultId { get; set; }
    
    public string Name { get; set; }
}