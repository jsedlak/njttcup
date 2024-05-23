using CupKeeper.Cqrs;
using CupKeeper.Domains.Locations.Model;

namespace CupKeeper.Domains.Locations.Events;

public sealed class VenueCreatedEvent : AggregateEvent
{
    public VenueCreatedEvent()
    {
    }

    public VenueCreatedEvent(Guid aggregateId) 
        : base(aggregateId)
    {
    }

    public string Name { get; set; } = null!;

    public Address? ParkingAddress { get; set; } = null!;

    public Address? StartLineAddress { get; set; } = null!;
}
