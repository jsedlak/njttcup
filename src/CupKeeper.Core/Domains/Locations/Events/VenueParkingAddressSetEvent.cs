using CupKeeper.Cqrs;
using CupKeeper.Domains.Locations.Model;

namespace CupKeeper.Domains.Locations.Events;

[GenerateSerializer]
public sealed class VenueParkingAddressSetEvent : VenueBaseEvent
{
    public VenueParkingAddressSetEvent(Guid aggregateId) 
        : base(aggregateId)
    {
    }

    [Id(0)]
    public Address? ParkingAddress { get; set; } = null!;
}