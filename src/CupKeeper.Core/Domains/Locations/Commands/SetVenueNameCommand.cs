namespace CupKeeper.Domains.Locations.Commands;

[GenerateSerializer]
public sealed class SetVenueNameCommand : ExistingVenueCommandBase
{
    public SetVenueNameCommand(Guid venueId) 
        : base(venueId)
    {
    }
    
    [Id(0)]
    public string Name { get; set; } = null!;
}
