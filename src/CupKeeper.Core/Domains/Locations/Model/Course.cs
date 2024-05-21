namespace CupKeeper.Domains.Locations.Model;

public sealed class Course
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = null!;

    public Address? Address { get; set; }
}
