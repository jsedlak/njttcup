using CupKeeper.Domains.Locations.Model;

namespace CupKeeper.Domains.Locations.Commands;

[GenerateSerializer]
public sealed class CreateVenueCommand
{
    [Id(0)]
    public string Name { get; set; } = null!;

    [Id(1)]
    public Address ParkingAddress { get; set; } = new();
}
