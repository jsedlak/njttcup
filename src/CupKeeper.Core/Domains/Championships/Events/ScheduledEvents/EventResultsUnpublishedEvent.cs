namespace CupKeeper.Domains.Championships.Events.ScheduledEvents;

[GenerateSerializer]
public sealed class EventResultsUnpublishedEvent : ScheduledEventBaseEvent
{
    public EventResultsUnpublishedEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }
}