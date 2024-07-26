using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Locations.Events;

[GenerateSerializer]
public sealed class CourseRouteDataSetEvent : VenueBaseEvent
{
    public CourseRouteDataSetEvent(Guid aggregateId) 
        : base(aggregateId)
    {
    }

    [Id(0)]
    public Guid CourseId { get; set; }

    [Id(1)]
    public string? RouteLink { get; set; } = null!;

    [Id(2)]
    public string? RideWithGpsId { get; set; } = null!;

    [Id(3)]
    public double Mileage { get; set; }
}