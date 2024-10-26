namespace CupKeeper.Domains.Championships.Commands;

[GenerateSerializer]
public sealed class UnpublishEventResultsCommand : ExistingScheduledEventCommandBase
{
    public UnpublishEventResultsCommand(Guid scheduledEventId) 
        : base(scheduledEventId)
    {
    }
}