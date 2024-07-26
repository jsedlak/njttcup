using CupKeeper.Cqrs;
using CupKeeper.Domains.Locations.Model;

namespace CupKeeper.Domains.Locations.Events;

[GenerateSerializer]
public sealed class VenueCreatedEvent : VenueBaseEvent
{
    public VenueCreatedEvent(Guid aggregateId) 
        : base(aggregateId)
    {
    }

    [Id(0)]
    public string Name { get; set; } = null!;

    [Id(1)]
    public Address? ParkingAddress { get; set; } = null!;
}