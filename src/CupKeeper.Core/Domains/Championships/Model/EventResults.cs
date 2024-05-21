using CupKeeper.Cqrs;

namespace CupKeeper.Domains.Championships.Model;

public sealed class EventResults : IAggregateRoot
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid ScheduledEventId { get; set; }
}
