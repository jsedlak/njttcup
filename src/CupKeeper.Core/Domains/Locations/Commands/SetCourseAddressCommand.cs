using CupKeeper.Domains.Locations.Model;

namespace CupKeeper.Domains.Locations.Commands;

[GenerateSerializer]
public sealed class SetCourseAddressCommand : ExistingVenueCourseCommandBase
{
    public SetCourseAddressCommand(Guid venueId, Guid courseId) 
        : base(venueId, courseId)
    {
    }
    
    [Id(0)]
    public Address? Address { get; set; }
}