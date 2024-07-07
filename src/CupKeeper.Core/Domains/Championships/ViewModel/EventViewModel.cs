using CupKeeper.Domains.Championships.Model;

namespace CupKeeper.Domains.Championships.ViewModel;

public class EventViewModel
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = null!;

    public Guid VenueId { get; set; }
    
    public Guid CourseId { get; set; }

    public string VenueName { get; set; } = null!;

    public string CourseName { get; set; } = null!;
    
    public int ChampionshipYear { get; set; }

    public DateTimeOffset? ScheduledDate { get; set; }
    
    public DateTimeOffset? ActualDate { get; set; }

    public string? RegistrationLink { get; set; }
    
    public string? UsacResultsLink { get; set; }
    
    public string? UsacPermitNumber { get; set; }

    public IEnumerable<CategoryResult> Results { get; set; } = [];
}