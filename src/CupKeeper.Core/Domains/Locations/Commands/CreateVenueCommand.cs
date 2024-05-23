using CupKeeper.Domains.Locations.Model;

namespace CupKeeper.Domains.Locations.Commands;

public sealed class CreateVenueCommand
{
    public string Name { get; set; } = null!;

    public Address? ParkingAddress { get; set; } = null!;

    public Address? StartLineAddress { get; set; } = null!;
}
