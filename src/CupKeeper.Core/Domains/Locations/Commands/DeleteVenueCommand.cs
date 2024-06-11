namespace CupKeeper.Domains.Locations.Commands;

[GenerateSerializer]
public sealed class DeleteVenueCommand : ExistingVenueCommandBase
{
    public DeleteVenueCommand(Guid venueId) 
        : base(venueId)
    {
    }
}
