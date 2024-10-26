namespace CupKeeper.Domains.Championships.Commands;

[GenerateSerializer]
public sealed class UndeleteScheduledEventCommand : ExistingScheduledEventCommandBase
{
    public UndeleteScheduledEventCommand(Guid scheduledEventId) 
        : base(scheduledEventId)
    {
    }
}