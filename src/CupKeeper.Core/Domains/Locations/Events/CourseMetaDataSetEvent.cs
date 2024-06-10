using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Locations.Events;

public sealed class CourseMetaDataSetEvent : AggregateEvent
{
    public CourseMetaDataSetEvent()
    {
    }

    public CourseMetaDataSetEvent(Guid aggregateId) 
        : base(aggregateId)
    {
    }

    public Guid CourseId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}