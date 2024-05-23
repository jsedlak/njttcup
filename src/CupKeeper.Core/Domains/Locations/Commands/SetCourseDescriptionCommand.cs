namespace CupKeeper.Domains.Locations.Commands;

public sealed class SetCourseDescriptionCommand : ExistingVenueCourseCommandBase
{
    public string? Description { get; set; }
}
