using CupKeeper.Domains.Locations.Model;

namespace CupKeeper.Domains.Locations.Commands;

[GenerateSerializer]
public sealed class AddCourseToVenueCommand : ExistingVenueCommandBase
{
    public AddCourseToVenueCommand(Guid venueId) 
        : base(venueId)
    {
    }
    
    [Id(0)]
    public string Name { get; set; } = null!;

    [Id(1)]
    public string? Description { get; set; }

    [Id(2)]
    public string? RouteLink { get; set; }

    [Id(3)]
    public string? RideWithGpsId { get; set; }

    [Id(4)]
    public double Mileage { get; set; } = 0;

    [Id(5)]
    public Address? Address { get; set; }
}
