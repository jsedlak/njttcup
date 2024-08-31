using CupKeeper.Domains.Championships.Events.ScheduledEvents;

namespace CupKeeper.Domains.Championships.Messages;

[GenerateSerializer]
public class ReloadRiderRequest : ScheduledEventBaseEvent
{
    public ReloadRiderRequest(Guid scheduledEventId) 
        : base(scheduledEventId)
    {
    }

    [Id(0)] public Guid RiderId { get; set; }
}