using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.ScheduledEvents;

[GenerateSerializer]
public sealed class EventRegistrationLinkSetEvent : AggregateEvent
{
    public EventRegistrationLinkSetEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }

    [Id(0)]
    public string? RegistrationLink { get; set; }
}