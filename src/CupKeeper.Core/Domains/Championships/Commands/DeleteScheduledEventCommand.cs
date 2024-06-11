namespace CupKeeper.Domains.Championships.Commands;

[GenerateSerializer]
public sealed class DeleteScheduledEventCommand : ExistingScheduledEventCommandBase
{
    public DeleteScheduledEventCommand(Guid scheduledEventId) 
        : base(scheduledEventId)
    {
    }
}
