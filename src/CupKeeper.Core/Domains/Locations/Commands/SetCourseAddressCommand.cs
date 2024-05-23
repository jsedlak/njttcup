using CupKeeper.Domains.Locations.Model;

namespace CupKeeper.Domains.Locations.Commands;

public sealed class SetCourseAddressCommand : ExistingVenueCourseCommandBase
{
    public Address? Address { get; set; }
}