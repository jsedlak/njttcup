using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupKeeper.Cqrs;

[GenerateSerializer]
public abstract class AggregateEvent : IAggregateEvent
{
    protected AggregateEvent() { }

    protected AggregateEvent(Guid aggregateId) 
        : this(aggregateId, DateTimeOffset.UtcNow)
    {
    }

    protected AggregateEvent(Guid aggregateId, DateTimeOffset timestamp)
    {
        AggregateId = aggregateId;
        Timestamp = timestamp;
    }

    [Id(0)]
    public Guid AggregateId { get; set; }

    [Id(1)]
    public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.UtcNow;
}
