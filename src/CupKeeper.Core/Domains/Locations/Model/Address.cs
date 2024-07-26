namespace CupKeeper.Domains.Locations.Model;

/// <summary>
/// Represents a physical location
/// </summary>
[GenerateSerializer]
public sealed record Address
{
    /// <summary>
    /// Gets or Sets the street address (Address 1)
    /// </summary>
    [Id(0)]
    public string StreetAddress { get; set; } = null!;

    /// <summary>
    /// Gets or Sets the second line of the street address (Address 2)
    /// </summary>
    [Id(1)]
    public string? AdditionalStreetAddress { get; set; }

    /// <summary>
    /// Gets or Sets the city
    /// </summary>
    [Id(2)]
    public string City { get; set; } = null!;

    /// <summary>
    /// Gets or Sets the state
    /// </summary>
    [Id(3)]
    public string State { get; set; } = null!;

    /// <summary>
    /// Gets or Sets the zip code
    /// </summary>
    [Id(4)] 
    public string? ZipCode { get; set; } = null;

    /// <summary>
    /// Gets or Sets the country code
    /// </summary>
    [Id(5)]
    public string? Country { get; set; } = null;
}
