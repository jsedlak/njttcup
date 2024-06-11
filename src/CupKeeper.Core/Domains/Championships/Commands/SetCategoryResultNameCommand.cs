namespace CupKeeper.Domains.Championships.Commands;

[GenerateSerializer]
public sealed class SetCategoryResultNameCommand : ExistingScheduledEventCommandBase
{
    public SetCategoryResultNameCommand(Guid scheduledEventId) 
        : base(scheduledEventId)
    {
    }
    
    [Id(0)]
    public string Name { get; set; } = null!;
}
