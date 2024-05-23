using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Locations.Events;

public sealed class CourseRouteDataSetEvent : AggregateEvent
{
    public CourseRouteDataSetEvent()
    {
    }

    public CourseRouteDataSetEvent(Guid aggregateId) 
        : base(aggregateId)
    {
    }

    public Guid CourseId { get; set; }

    public string RouteLink { get; set; } = null!;

    public string RideWithGpsId { get; set; } = null!;
}