namespace CupKeeper.Domains.Championships.Commands;

public sealed class SetCategoryResultNameCommand : ExistingScheduledEventCommandBase
{
    public string Name { get; set; } = null!;
}
