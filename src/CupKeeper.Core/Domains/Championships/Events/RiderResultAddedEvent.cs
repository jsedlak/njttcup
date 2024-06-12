using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events;

public sealed class RiderResultAddedEvent : AggregateEvent
{
    public RiderResultAddedEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }
    
    public Guid CategoryResultId { get; set; }

    public Guid RiderId { get; set; }

    public int Position { get; set; }

    public string? Team { get; set; }

    public string? LicenseNumber { get; set; }
    
    public string? UsacCategory { get; set; }
    
    public string? Time { get; set; }

    public string? Points { get; set; }
}