using CupKeeper.Cqrs;
using CupKeeper.Domains.Championships.Model;

namespace CupKeeper.Domains.Championships.Events.ScheduledEvents;

[GenerateSerializer]
public sealed class EventResultsLoadedEvent : AggregateEvent
{
    public EventResultsLoadedEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }
    
    [Id(0)]
    public IEnumerable<CategoryResult> Categories { get; set; }
}