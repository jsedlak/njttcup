namespace CupKeeper.Domains.Championships.Commands;

public sealed class MoveRiderResultCommand : ExistingScheduledEventCommandBase
{
    public Guid SourceCategoryResultId { get; set; }

    public Guid RiderResultId { get; set; }

    public Guid TargetCategoryResultId { get; set; }
}