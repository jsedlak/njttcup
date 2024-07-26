using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Locations.Events;

[GenerateSerializer]
public sealed class VenueNameSetEvent : VenueBaseEvent
{
    public VenueNameSetEvent(Guid aggregateId) 
        : base(aggregateId)
    {
    }

    [Id(0)]
    public string Name { get; set; } = null!;
}