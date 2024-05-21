using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Membership.Model;

public sealed class Rider : IAggregateRoot
{
    public Guid Id {  get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string? TeamName { get; set; }

    public string? UsacLicenseNumber { get; set; }
}
