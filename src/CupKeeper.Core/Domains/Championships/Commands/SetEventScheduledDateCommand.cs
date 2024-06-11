namespace CupKeeper.Domains.Championships.Commands;

[GenerateSerializer]
public sealed class SetEventScheduledDateCommand : ExistingScheduledEventCommandBase
{
    public SetEventScheduledDateCommand(Guid scheduledEventId) 
        : base(scheduledEventId)
    {
    }
    
    [Id(0)]
    public DateTimeOffset ScheduledDate { get; set; }
}
