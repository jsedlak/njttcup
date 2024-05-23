using CupKeeper.Domains.Locations.Model;

namespace CupKeeper.Domains.Locations.Commands;

public sealed class SetVenueStartLineAddressCommand : ExistingVenueCommandBase
{
    public Address? StartLineAddress { get; set; } = null!;
}
