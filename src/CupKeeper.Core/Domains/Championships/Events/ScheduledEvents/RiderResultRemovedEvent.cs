using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.ScheduledEvents;

[GenerateSerializer]
public sealed class RiderResultRemovedEvent : AggregateEvent
{
    public RiderResultRemovedEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }

    [Id(0)]
    public Guid RiderResultId { get; set; }
    
    [Id(1)]
    public Guid CategoryResultId { get; set; }
}