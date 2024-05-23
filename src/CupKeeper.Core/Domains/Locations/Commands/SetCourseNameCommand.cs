namespace CupKeeper.Domains.Locations.Commands;

public sealed class SetCourseNameCommand : ExistingVenueCourseCommandBase
{
    public string Name { get; set; } = null!;
}
