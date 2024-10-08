using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.ScheduledEvents;

[GenerateSerializer]
public sealed class CategoryResultAddedEvent : ScheduledEventBaseEvent
{
    public CategoryResultAddedEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
    }

    [Id(0)] public Guid CategoryId { get; set; }

    [Id(1)] public string Name { get; set; } = null!;

    [Id(2)] public int Order { get; set; }
}