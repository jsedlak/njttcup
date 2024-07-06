namespace CupKeeper.Domains.Championships.Commands;

[GenerateSerializer]
public sealed class CreateEventResultsCommand : ExistingScheduledEventCommandBase
{
    public CreateEventResultsCommand(Guid scheduledEventId) 
        : base(scheduledEventId)
    {
    }
    
    [Id(0)]
    public DateTimeOffset EventDate { get; set; }
}
