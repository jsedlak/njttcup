namespace CupKeeper.Domains.Locations.Commands;

/// <summary>
/// Represents the base class for commands that require an existing venue
/// </summary>
public abstract class ExistingVenueCommandBase
{
    public Guid VenueId { get; set; }
}
