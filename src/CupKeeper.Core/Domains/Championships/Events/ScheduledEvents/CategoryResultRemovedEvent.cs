using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.ScheduledEvents;

[GenerateSerializer]
public sealed class CategoryResultRemovedEvent : AggregateEvent
{
    public CategoryResultRemovedEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }

    [Id(0)]
    public Guid CategoryResultId { get; set; }
}