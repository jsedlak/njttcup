namespace CupKeeper.Domains.Championships.Commands;

public sealed class CreateScheduledEventCommand
{
    public string Name { get; set; } = null!;

    public Guid VenueId { get; set; }

    public Guid CourseId { get; set; }

    public DateTimeOffset ScheduledDate { get; set; }

    public string? RegistrationLink { get; set; }

    public string? UsacResultsLink { get; set; }

    public string? UsacPermitNumber { get; set; }
}
