namespace CupKeeper.Domains.Locations.Commands;

public sealed class SetCourseRouteDataCommand : ExistingVenueCourseCommandBase
{
    public string? RouteLink { get; set; }

    public string? RideWithGpsId { get; set; }

    public double Mileage { get; set; } = 0;
}
