using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.ScheduledEvents;

[GenerateSerializer]
public sealed class CategoryResultNameSetEvent : ScheduledEventBaseEvent
{
    public CategoryResultNameSetEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }

    [Id(0)]
    public Guid CategoryResultId { get; set; }

    [Id(1)] public string Name { get; set; } = null!;
}