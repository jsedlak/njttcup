using CupKeeper.Cqrs;
using CupKeeper.Domains.Locations.Model;

namespace CupKeeper.Domains.Locations.Events;

public sealed class VenueStartLineAddressSetEvent : AggregateEvent
{
    public VenueStartLineAddressSetEvent()
    {
    }

    public VenueStartLineAddressSetEvent(Guid aggregateId) 
        : base(aggregateId)
    {
    }

    public Address? StartLineAddress { get; set; } = null!;
}
