namespace CupKeeper.Domains.Locations.Model;

public sealed class Address
{
    public string StreetAddress { get; set; } = null!;

    public string? AdditionalStreetAddress { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }
}
