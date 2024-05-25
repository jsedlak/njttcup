namespace CupKeeper.Domains.Championships.Commands;

public sealed class SetEventScheduledDateCommand : ExistingScheduledEventCommandBase
{
    public DateTimeOffset ScheduledDate { get; set; }
}
