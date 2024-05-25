namespace CupKeeper.Domains.Championships.Commands;

public sealed class RemoveRiderResultCommand : ExistingScheduledEventCommandBase
{
    public Guid CategoryResultId { get; set; }

    public Guid RiderResultId { get; set; }
}
