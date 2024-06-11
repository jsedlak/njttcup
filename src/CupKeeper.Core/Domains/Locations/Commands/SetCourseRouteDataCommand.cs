namespace CupKeeper.Domains.Locations.Commands;

[GenerateSerializer]
public sealed class SetCourseRouteDataCommand : ExistingVenueCourseCommandBase
{
    public SetCourseRouteDataCommand(Guid venueId, Guid courseId) 
        : base(venueId, courseId)
    {
    }
    
    [Id(0)]
    public string? RouteLink { get; set; }

    [Id(1)]
    public string? RideWithGpsId { get; set; }

    [Id(2)]
    public double Mileage { get; set; } = 0;
}
