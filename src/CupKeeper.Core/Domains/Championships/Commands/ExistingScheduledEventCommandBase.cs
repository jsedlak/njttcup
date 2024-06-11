namespace CupKeeper.Domains.Championships.Commands;

[GenerateSerializer]
public abstract class ExistingScheduledEventCommandBase
{
    protected ExistingScheduledEventCommandBase(Guid scheduledEventId)
    {
        ScheduledEventId = scheduledEventId;
    }
    
    [Id(0)]
    public Guid ScheduledEventId { get; set; }
}
