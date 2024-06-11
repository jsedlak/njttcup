namespace CupKeeper.Domains.Championships.Commands;

[GenerateSerializer]
public sealed class PublishEventResultsCommand : ExistingScheduledEventCommandBase
{
    public PublishEventResultsCommand(Guid scheduledEventId) 
        : base(scheduledEventId)
    {
    }
}