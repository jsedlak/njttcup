using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Locations.Events;

public sealed class CourseNameSetEvent : AggregateEvent
{
    public CourseNameSetEvent()
    {
    }

    public CourseNameSetEvent(Guid aggregateId) 
        : base(aggregateId)
    {
    }

    public Guid CourseId { get; set; }

    public string Name { get; set; } = null!;
}