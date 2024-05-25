namespace CupKeeper.Domains.Championships.Commands;

public sealed class SetEventUsacDataCommand : ExistingScheduledEventCommandBase
{
    public string? UsacPermitNumber { get; set; } = null!;

    public string? UsacResultsLink { get; set; } = null!;
}
