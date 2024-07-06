namespace CupKeeper.Domains.Championships.Commands;

[GenerateSerializer]
public sealed class CreateScheduledEventCommand
{
    [Id(0)]
    public string Name { get; set; } = null!;

    [Id(1)]
    public Guid VenueId { get; set; }

    [Id(2)]
    public Guid CourseId { get; set; }

    [Id(3)]
    public DateTimeOffset? ScheduledDate { get; set; }

    [Id(4)]
    public string? RegistrationLink { get; set; }

    [Id(5)]
    public string? UsacResultsLink { get; set; }

    [Id(6)]
    public string? UsacPermitNumber { get; set; }
}
