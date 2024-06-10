namespace CupKeeper.Cqrs;

public interface IAggregateEvent
{
    Guid AggregateId { get; set; }

    DateTimeOffset Timestamp { get; set; }
}
