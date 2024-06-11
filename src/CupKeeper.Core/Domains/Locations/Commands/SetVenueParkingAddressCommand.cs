using CupKeeper.Domains.Locations.Model;

namespace CupKeeper.Domains.Locations.Commands;

[GenerateSerializer]
public sealed class SetVenueParkingAddressCommand : ExistingVenueCommandBase
{
    public SetVenueParkingAddressCommand(Guid venueId) 
        : base(venueId)
    {
    }
    
    [Id(0)]
    public Address? ParkingAddress { get; set; } = null!;
}
