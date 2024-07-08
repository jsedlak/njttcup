namespace CupKeeper.Domains.Locations.Commands;

/// <summary>
/// Represents the base class for commands that require an existing venue
/// </summary>
[GenerateSerializer]
public abstract class ExistingVenueCommandBase
{
    protected ExistingVenueCommandBase(Guid venueId)
    {
        VenueId = venueId;
    }
    
    [Id(0)]
    public Guid VenueId { get; set; }
}
