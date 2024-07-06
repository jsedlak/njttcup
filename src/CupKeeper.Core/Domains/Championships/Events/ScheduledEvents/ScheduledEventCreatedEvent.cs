using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Events;

public sealed class ScheduledEventCreatedEvent : AggregateEvent
{
    public ScheduledEventCreatedEvent(Guid scheduledEventId)
        : base(scheduledEventId)
    {
        
    }

    public string Name { get; set; } = null!;

    public Guid VenueId { get; set; }
    
    public Guid CourseId { get; set; }
    
    public DateTimeOffset? ScheduledDate { get; set; }
    
    public string? RegistrationLink { get; set; }
    
    public string? UsacResultsLink { get; set; }
    
    public string? UsacPermitNubmer { get; set; }
}