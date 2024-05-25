namespace CupKeeper.Domains.Championships.Commands;

public sealed class SetEventNameCommand : ExistingScheduledEventCommandBase
{
    public string Name { get; set; } = null!;
}
