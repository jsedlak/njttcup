namespace CupKeeper.Domains.Championships.Commands;

[GenerateSerializer]
public sealed class MoveRiderResultCommand : ExistingScheduledEventCommandBase
{
    public MoveRiderResultCommand(Guid scheduledEventId) 
        : base(scheduledEventId)
    {
    }
    
    [Id(0)]
    public Guid SourceCategoryResultId { get; set; }

    [Id(1)]
    public Guid RiderResultId { get; set; }

    [Id(2)]
    public Guid TargetCategoryResultId { get; set; }
}