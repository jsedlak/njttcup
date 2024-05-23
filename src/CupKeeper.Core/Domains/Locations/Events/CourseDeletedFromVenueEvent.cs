using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Locations.Events;

public sealed class CourseDeletedFromVenueEvent : AggregateEvent
{
    public CourseDeletedFromVenueEvent()
    {
    }

    public CourseDeletedFromVenueEvent(Guid aggregateId) 
        : base(aggregateId)
    {
    }

    public Guid CourseId { get; set; }
}