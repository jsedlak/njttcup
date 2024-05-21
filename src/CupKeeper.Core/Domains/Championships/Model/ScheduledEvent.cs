using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Model;

public sealed class ScheduledEvent : IAggregateRoot
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid VenueId { get; set; }

    public Guid CourseId { get; set; }

    public string Name { get; set; } = null!;

    public string? RegistrationLink { get; set; }

    public string? UsacResultsLink { get; set; }
}
