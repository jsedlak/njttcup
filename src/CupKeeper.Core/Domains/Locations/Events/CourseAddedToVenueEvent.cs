using CupKeeper.Cqrs;
using CupKeeper.Domains.Locations.Model;

namespace CupKeeper.Domains.Locations.Events;

public sealed class CourseAddedToVenueEvent : AggregateEvent
{
    public CourseAddedToVenueEvent()
    {
    }

    public CourseAddedToVenueEvent(Guid aggregateId) 
        : base(aggregateId)
    {
    }

    public Guid CourseId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? RouteLink { get; set; }

    public string? RideWithGpsId { get; set; }

    public double Mileage { get; set; } = 0;

    public Address? Address { get; set; }
}