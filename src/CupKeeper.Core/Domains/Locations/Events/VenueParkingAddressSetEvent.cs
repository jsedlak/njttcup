using CupKeeper.Cqrs;
using CupKeeper.Domains.Locations.Model;

namespace CupKeeper.Domains.Locations.Events;

public sealed class VenueParkingAddressSetEvent : AggregateEvent
{
    public VenueParkingAddressSetEvent()
    {
    }

    public VenueParkingAddressSetEvent(Guid aggregateId) 
        : base(aggregateId)
    {
    }

    public Address? ParkingAddress { get; set; } = null!;
}