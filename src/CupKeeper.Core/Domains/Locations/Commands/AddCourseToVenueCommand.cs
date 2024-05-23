using CupKeeper.Domains.Locations.Model;

namespace CupKeeper.Domains.Locations.Commands;

public sealed class AddCourseToVenueCommand : ExistingVenueCommandBase
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? RouteLink { get; set; }

    public string? RideWithGpsId { get; set; }

    public double Mileage { get; set; } = 0;

    public Address? Address { get; set; }
}
