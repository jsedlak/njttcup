namespace CupKeeper.Domains.Championships.Commands;

public sealed class RemoveCategoryResultCommand : ExistingScheduledEventCommandBase
{
    public Guid CategoryResultId { get; set; }
}
