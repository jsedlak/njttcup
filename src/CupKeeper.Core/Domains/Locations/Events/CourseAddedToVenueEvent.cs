using CupKeeper.Cqrs;
using CupKeeper.Domains.Locations.Model;

namespace CupKeeper.Domains.Locations.Events;

[GenerateSerializer]
public sealed class CourseAddedToVenueEvent : VenueBaseEvent
{
    public CourseAddedToVenueEvent(Guid aggregateId) 
        : base(aggregateId)
    {
    }

    [Id(0)]
    public Guid CourseId { get; set; }

    [Id(1)]
    public string Name { get; set; } = null!;

    [Id(2)]
    public string? Description { get; set; }

    [Id(3)]
    public string? RouteLink { get; set; }

    [Id(4)]
    public string? RideWithGpsId { get; set; }

    [Id(5)]
    public double Mileage { get; set; } = 0;

    [Id(6)]
    public Address? Address { get; set; }
}