namespace CupKeeper.Domains.Locations.Commands;

public sealed class SetCourseMetaData : ExistingVenueCourseCommandBase
{
    public string Name { get; set; } = null!;
    
    public string? Description { get; set; }
}
