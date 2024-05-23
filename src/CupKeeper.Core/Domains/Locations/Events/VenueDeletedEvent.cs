using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Locations.Events;

public sealed class VenueDeletedEvent : AggregateEvent
{
    public VenueDeletedEvent()
    {
    }

    public VenueDeletedEvent(Guid aggregateId) 
        : base(aggregateId)
    {
    }
}