using CupKeeper.Cqrs;
using CupKeeper.Domains.Locations.Model;

namespace CupKeeper.Domains.Locations.Events;

public sealed class CourseAddressSetEvent : AggregateEvent
{
    public CourseAddressSetEvent()
    {
    }

    public CourseAddressSetEvent(Guid aggregateId) 
        : base(aggregateId)
    {
    }

    public Guid CourseId { get; set; }

    public Address? Address { get; set; }
}