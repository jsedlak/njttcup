using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Locations.Model;

public sealed class Venue : IAggregateRoot
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = "Untitled Venue";

    public Address Address { get; set; } = null!;

    public IEnumerable<Course> Courses { get; set; } = Enumerable.Empty<Course>();
}
