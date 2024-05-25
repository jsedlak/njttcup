namespace CupKeeper.Domains.Championships.Commands;

public sealed class CreateEventResultsCommand : ExistingScheduledEventCommandBase
{
    public DateTimeOffset EventDate { get; set; }
}
