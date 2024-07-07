using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.ScheduledEvents;

[GenerateSerializer]
public sealed class RiderResultMovedEvent : ScheduledEventBaseEvent
{
    public RiderResultMovedEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }
    
    [Id(0)]
    public Guid SourceCategoryResultId { get; set; }

    [Id(1)]
    public Guid RiderResultId { get; set; }

    [Id(2)]
    public Guid TargetCategoryResultId { get; set; }
}