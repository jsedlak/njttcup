using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.ScheduledEvents;

[GenerateSerializer]
public sealed class EventNameSetEvent : AggregateEvent
{
    public EventNameSetEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }

    [Id(0)]
    public string Name { get; set; } = null!;
}