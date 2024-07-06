using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events;

public sealed class EventRegistrationLinkSetEvent : AggregateEvent
{
    public EventRegistrationLinkSetEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }

    public string? RegistrationLink { get; set; }
}