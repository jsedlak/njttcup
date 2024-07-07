using CupKeeper.Cqrs;
using CupKeeper.Domains.Championships.Events.ScheduledEvents;

namespace CupKeeper.Domains.Championships.Model;

/// <summary>
/// Represents a scheduled event on the race calendar for a given year
/// </summary>
[GenerateSerializer]
public sealed class ScheduledEvent : IAggregateRoot
{
    /// <summary>
    /// Gets or Sets the unique identifier for the scheduled event
    /// </summary>
    [Id(0)]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or Sets the referenced venue identifier
    /// </summary>
    [Id(1)]
    public Guid VenueId { get; set; }

    /// <summary>
    /// Gets or Sets the particular course's identifier within the venue
    /// </summary>
    [Id(2)]
    public Guid CourseId { get; set; }

    /// <summary>
    /// Gets or Sets the name of the event
    /// </summary>
    [Id(3)]
    public string Name { get; set; } = null!;
    
    /// <summary>
    /// Gets or Sets when the event is scheduled to occur
    /// </summary>
    [Id(4)]
    public DateTimeOffset? ScheduledDate { get; set; }

    /// <summary>
    /// Gets or Sets when the event actually occurred
    /// </summary>
    [Id(5)]
    public DateTimeOffset? ActualDate { get; set; }

    /// <summary>
    /// Gets or Sets the link to register for the event
    /// </summary>
    [Id(6)]
    public string? RegistrationLink { get; set; }

    /// <summary>
    /// Gets or Sets the link to the results
    /// </summary>
    [Id(7)]
    public string? UsacResultsLink { get; set; }

    /// <summary>
    /// Gets or Sets the USA Cycling permit number
    /// </summary>
    [Id(8)]
    public string? UsacPermitNumber { get; set; }

    /// <summary>
    /// Gets or Sets the set of results for the event
    /// </summary>
    [Id(9)]
    public EventResult? Results { get; set; } = new();
    
    /// <summary>
    /// Gets or Sets whether the event is deleted and is ready to be permanently removes
    /// </summary>
    [Id(10)]
    public bool IsDeleted { get; set; }
    
    #region Event Management Events

    public void Apply(ScheduledEventCreatedEvent @event)
    {
        Name = @event.Name;
        VenueId = @event.VenueId;
        CourseId = @event.CourseId;
        ScheduledDate = @event.ScheduledDate;
        RegistrationLink = @event.RegistrationLink;
        UsacResultsLink = @event.UsacResultsLink;
        UsacPermitNumber = @event.UsacPermitNumber;
    }

    public void Apply(ScheduledEventDeletedEvent @event)
    {
        IsDeleted = true;
    }

    public void Apply(EventCourseSetEvent @event)
    {
        VenueId = @event.VenueId;
        CourseId = @event.CourseId;
    }

    public void Apply(EventDatesSetEvent @event)
    {
        ScheduledDate = @event.ScheduledDate;
        ActualDate = @event.ActualDate;
    }

    public void Apply(EventNameSetEvent @event)
    {
        Name = @event.Name;
    }

    public void Apply(EventRegistrationLinkSetEvent @event)
    {
        RegistrationLink = @event.RegistrationLink;
    }

    public void Apply(EventUsacDataSetEvent @event)
    {
        UsacPermitNumber = @event.UsacPermitNumber;
        UsacResultsLink = @event.UsacResultsLink;
    }
    #endregion

    #region Results
    public void Apply(EventResultsCreatedEvent @event)
    {
        // TODO: What do here?
    }

    public void Apply(EventResultsLoadedEvent @event)
    {
        if (Results is null)
        {
            return;
        }
        
        Results.Categories = @event.Categories;
    }

    public void Apply(EventResultsPublishedEvent @event)
    {
        
    }

    public void Apply(RiderResultAddedEvent @event)
    {
        
    }

    public void Apply(RiderResultMovedEvent @event)
    {
        
    }

    public void Apply(RiderResultRemovedEvent @event)
    {
        
    }
    #endregion
}
