using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Locations.Events;

[GenerateSerializer]
public sealed class CourseMetaDataSetEvent : VenueBaseEvent
{
    public CourseMetaDataSetEvent(Guid aggregateId) 
        : base(aggregateId)
    {
    }

    [Id(0)]
    public Guid CourseId { get; set; }

    [Id(1)]
    public string Name { get; set; } = null!;

    [Id(2)]
    public string? Description { get; set; }
}