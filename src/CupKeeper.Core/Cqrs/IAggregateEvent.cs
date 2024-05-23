using Petl;

namespace CupKeeper.Cqrs;

public interface IAggregateEvent : IResponse
{
    Guid AggregateId { get; set; }

    DateTimeOffset Timestamp { get; set; }
}
