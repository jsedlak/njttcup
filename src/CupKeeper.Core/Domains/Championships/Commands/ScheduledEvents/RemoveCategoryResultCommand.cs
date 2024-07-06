namespace CupKeeper.Domains.Championships.Commands;

[GenerateSerializer]
public sealed class RemoveCategoryResultCommand : ExistingScheduledEventCommandBase
{
    public RemoveCategoryResultCommand(Guid scheduledEventId) 
        : base(scheduledEventId)
    {
    }
    
    [Id(0)]
    public Guid CategoryResultId { get; set; }
}
