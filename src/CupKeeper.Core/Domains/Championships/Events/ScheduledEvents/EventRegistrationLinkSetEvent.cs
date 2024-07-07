using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events.ScheduledEvents;

[GenerateSerializer]
public sealed class EventRegistrationLinkSetEvent : ScheduledEventBaseEvent
{
    public EventRegistrationLinkSetEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }

    [Id(0)]
    public string? RegistrationLink { get; set; }
}