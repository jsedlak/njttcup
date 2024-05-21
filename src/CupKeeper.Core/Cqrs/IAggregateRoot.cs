namespace CupKeeper.Cqrs;

public interface IAggregateRoot
{
    Guid Id { get; set; }
}
