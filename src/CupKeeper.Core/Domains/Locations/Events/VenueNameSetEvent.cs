using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Locations.Events;

public sealed class VenueNameSetEvent : AggregateEvent
{
    public VenueNameSetEvent()
    {
    }

    public VenueNameSetEvent(Guid aggregateId) 
        : base(aggregateId)
    {
    }

    public string Name { get; set; } = null!;
}