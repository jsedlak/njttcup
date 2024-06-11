namespace CupKeeper.Domains.Championships.Commands;

[GenerateSerializer]
public sealed class RemoveRiderResultCommand : ExistingScheduledEventCommandBase
{
    public RemoveRiderResultCommand(Guid scheduledEventId) 
        : base(scheduledEventId)
    {
    }
    
    [Id(0)]
    public Guid CategoryResultId { get; set; }

    [Id(1)]
    public Guid RiderResultId { get; set; }
}
