using CupKeeper.Data;
using CupKeeper.Domains.Championships.Model;

namespace CupKeeper.Domains.Championships.ViewModel;

[GenerateSerializer]
public class EventViewModel : IView
{
    [Id(0)] public Guid Id { get; set; } = Guid.NewGuid();

    [Id(1)] public string Name { get; set; } = null!;

    [Id(2)] public Guid VenueId { get; set; }

    [Id(3)] public Guid CourseId { get; set; }

    [Id(4)] public string? VenueName { get; set; } = null!;

    [Id(5)] public string? CourseName { get; set; } = null!;

    [Id(6)] public int ChampionshipYear { get; set; }

    [Id(7)] public DateTimeOffset? ScheduledDate { get; set; }

    [Id(8)] public DateTimeOffset? ActualDate { get; set; }

    [Id(9)] public string? RegistrationLink { get; set; }

    [Id(10)] public string? UsacResultsLink { get; set; }

    [Id(11)] public string? UsacPermitNumber { get; set; }

    [Id(12)] public CategoryResultViewModel[] Results { get; set; } = [];

    [Id(13)] public bool IsDeleted { get; set; } = false;

    [Id(14)] public bool IsPublished { get; set; } = false;
}