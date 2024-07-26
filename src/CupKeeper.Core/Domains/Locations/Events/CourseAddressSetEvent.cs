using CupKeeper.Cqrs;
using CupKeeper.Domains.Locations.Model;

namespace CupKeeper.Domains.Locations.Events;

[GenerateSerializer]
public sealed class CourseAddressSetEvent : VenueBaseEvent
{
    public CourseAddressSetEvent(Guid aggregateId) 
        : base(aggregateId)
    {
    }

    [Id(0)]
    public Guid CourseId { get; set; }

    [Id(1)]
    public Address? Address { get; set; }
}