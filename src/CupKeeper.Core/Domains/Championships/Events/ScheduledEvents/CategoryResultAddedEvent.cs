using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.ScheduledEvents;

[GenerateSerializer]
public sealed class CategoryResultAddedEvent : AggregateEvent
{
    public CategoryResultAddedEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
    }

    [Id(0)] public string Name { get; set; }

    [Id(1)] public int Order { get; set; }
}