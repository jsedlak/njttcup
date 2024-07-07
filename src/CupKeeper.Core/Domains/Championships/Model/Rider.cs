using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Model;

/// <summary>
/// Represents a rider who has competed in scheduled events
/// </summary>
[GenerateSerializer]
public sealed class Rider : IAggregateRoot
{
    /// <summary>
    /// Gets or Sets the unique identifier for the rider
    /// </summary>
    [Id(0)]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or Sets the name of the rider
    /// </summary>
    [Id(1)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or Sets the team name of the rider
    /// </summary>
    [Id(2)]
    public string? TeamName { get; set; }

    /// <summary>
    /// Gets or Sets the USA Cycling License Number of the rider
    /// </summary>
    [Id(3)]
    public string? UsacLicenseNumber { get; set; }
}
