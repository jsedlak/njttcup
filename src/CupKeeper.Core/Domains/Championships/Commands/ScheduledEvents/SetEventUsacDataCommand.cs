namespace CupKeeper.Domains.Championships.Commands;

[GenerateSerializer]
public sealed class SetEventUsacDataCommand : ExistingScheduledEventCommandBase
{
    public SetEventUsacDataCommand(Guid scheduledEventId) 
        : base(scheduledEventId)
    {
    }
    
    [Id(0)]
    public string? UsacPermitNumber { get; set; } = null!;

    [Id(1)]
    public string? UsacResultsLink { get; set; } = null!;
}
