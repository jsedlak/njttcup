using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Locations.Events;

[GenerateSerializer]
public sealed class CourseDeletedFromVenueEvent : VenueBaseEvent
{
    public CourseDeletedFromVenueEvent(Guid aggregateId) 
        : base(aggregateId)
    {
    }

    [Id(0)]
    public Guid CourseId { get; set; }
}