namespace CupKeeper.Domains.Locations.Commands;

[GenerateSerializer]
public sealed class SetCourseMetaData : ExistingVenueCourseCommandBase
{
    public SetCourseMetaData(Guid venueId, Guid courseId) 
        : base(venueId, courseId)
    {
    }
    
    [Id(0)]
    public string Name { get; set; } = null!;
    
    [Id(1)]
    public string? Description { get; set; }
}
