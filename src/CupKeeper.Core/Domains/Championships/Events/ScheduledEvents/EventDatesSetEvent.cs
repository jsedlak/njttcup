using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.ScheduledEvents;

[GenerateSerializer]
public sealed class EventDatesSetEvent : AggregateEvent
{
    public EventDatesSetEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }

    [Id(0)]
    public DateTimeOffset? ScheduledDate { get; set; }
    
    [Id(1)]
    public DateTimeOffset? ActualDate { get; set; }
}