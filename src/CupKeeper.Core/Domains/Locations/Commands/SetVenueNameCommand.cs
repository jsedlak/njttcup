namespace CupKeeper.Domains.Locations.Commands;

public sealed class SetVenueNameCommand : ExistingVenueCommandBase
{
    public string Name { get; set; } = null!;
}
