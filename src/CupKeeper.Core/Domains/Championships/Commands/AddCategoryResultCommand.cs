namespace CupKeeper.Domains.Championships.Commands;

public sealed class AddCategoryResultCommand : ExistingScheduledEventCommandBase
{
    public string Name { get; set; } = null!;

    public int Order { get; set; }
}
