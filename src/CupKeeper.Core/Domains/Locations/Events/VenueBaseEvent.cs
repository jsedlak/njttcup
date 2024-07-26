using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Locations.Events;

[GenerateSerializer]
public abstract class VenueBaseEvent : AggregateEvent
{
    protected VenueBaseEvent(Guid venueId)
        : base(venueId)
    {
    }
}