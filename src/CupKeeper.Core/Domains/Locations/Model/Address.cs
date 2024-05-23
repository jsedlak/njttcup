namespace CupKeeper.Domains.Locations.Model;

/// <summary>
/// Represents a physical location
/// </summary>
public sealed record Address
{
    /// <summary>
    /// Gets or Sets the street address (Address 1)
    /// </summary>
    public string StreetAddress { get; set; } = null!;

    /// <summary>
    /// Gets or Sets the second line of the street address (Address 2)
    /// </summary>
    public string? AdditionalStreetAddress { get; set; }

    /// <summary>
    /// Gets or Sets the city
    /// </summary>
    public string City { get; set; } = null!;

    /// <summary>
    /// Gets or Sets the state
    /// </summary>
    public string State { get; set; } = null!;

    /// <summary>
    /// Gets or Sets the country code
    /// </summary>
    public string Country { get; set; } = null!;
}
