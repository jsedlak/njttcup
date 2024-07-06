using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events;

public sealed class EventResultsLoadedEvent : AggregateEvent
{
    public EventResultsLoadedEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }
    
    public IEnumerable<CategoryResult> Categories { get; set; }
}