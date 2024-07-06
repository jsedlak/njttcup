namespace CupKeeper.Domains.Championships.Commands;

[GenerateSerializer]
public sealed class SetEventDatesCommand : ExistingScheduledEventCommandBase
{
    public SetEventDatesCommand(Guid scheduledEventId) 
        : base(scheduledEventId)
    {
    }
    
    [Id(0)]
    public DateTimeOffset? ScheduledDate { get; set; }
    
    [Id(1)]
    public DateTimeOffset? ActualDate { get; set; }
}
