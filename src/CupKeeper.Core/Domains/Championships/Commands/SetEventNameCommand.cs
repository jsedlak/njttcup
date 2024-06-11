namespace CupKeeper.Domains.Championships.Commands;

[GenerateSerializer]
public sealed class SetEventNameCommand : ExistingScheduledEventCommandBase
{
    public SetEventNameCommand(Guid scheduledEventId) 
        : base(scheduledEventId)
    {
    }
    
    [Id(0)]
    public string Name { get; set; } = null!;
}
