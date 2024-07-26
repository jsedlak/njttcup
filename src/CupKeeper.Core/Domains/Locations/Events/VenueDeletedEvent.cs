using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Locations.Events;

[GenerateSerializer]
public sealed class VenueDeletedEvent : VenueBaseEvent
{
    public VenueDeletedEvent(Guid aggregateId) 
        : base(aggregateId)
    {
    }
}