using CupKeeper.Domains.Locations.Model;

namespace CupKeeper.Domains.Locations.Commands;

public sealed class SetVenueParkingAddressCommand : ExistingVenueCommandBase
{
    public Address? ParkingAddress { get; set; } = null!;
}
