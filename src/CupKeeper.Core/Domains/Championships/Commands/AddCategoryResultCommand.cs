namespace CupKeeper.Domains.Championships.Commands;

[GenerateSerializer]
public sealed class AddCategoryResultCommand : ExistingScheduledEventCommandBase
{
    public AddCategoryResultCommand(Guid scheduledEventId) 
        : base(scheduledEventId)
    {
    }
    
    [Id(0)]
    public string Name { get; set; } = null!;

    [Id(1)]
    public int Order { get; set; }
}