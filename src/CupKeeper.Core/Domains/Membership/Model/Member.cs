using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Membership.Model;

public sealed class Member : IAggregateRoot
{
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// The unique identifier tying them back to the identity provider
    /// </summary>
    public string AuthIdentifier { get; set; } = null!;

    /// <summary>
    /// Gets or Sets how the member would like their name to be represented across the site
    /// </summary>
    public string DisplayName { get; set; } = null!;

    /// <summary>
    /// Gets or Sets the member's rider profile's identifier
    /// </summary>
    public Guid RiderProfileId { get; set; }
}