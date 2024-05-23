using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Model;

/// <summary>
/// Represents a rider who has competed in scheduled events
/// </summary>
public sealed class Rider : IAggregateRoot
{
    /// <summary>
    /// Gets or Sets the unique identifier for the rider
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or Sets the name of the rider
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or Sets the team name of the rider
    /// </summary>
    public string? TeamName { get; set; }

    /// <summary>
    /// Gets or Sets the USA Cycling License Number of the rider
    /// </summary>
    public string? UsacLicenseNumber { get; set; }
}
