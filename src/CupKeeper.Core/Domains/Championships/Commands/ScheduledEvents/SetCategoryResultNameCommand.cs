namespace CupKeeper.Domains.Championships.Commands;

[GenerateSerializer]
public sealed class SetCategoryResultNameCommand : ExistingScheduledEventCommandBase
{
    public SetCategoryResultNameCommand(Guid scheduledEventId) 
        : base(scheduledEventId)
    {
    }

    [Id(0)] public Guid CategoryResultId { get; set; }

    [Id(1)] public string Name { get; set; } = null!;

    [Id(2)] public int Order { get; set; }
}
