using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.ScheduledEvents;

[GenerateSerializer]
public sealed class EventUsacDataSetEvent : ScheduledEventBaseEvent
{
    public EventUsacDataSetEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }

    [Id(0)]
    public string? UsacResultsLink { get; set; }
    
    [Id(1)]
    public string? UsacPermitNumber { get; set; }
}