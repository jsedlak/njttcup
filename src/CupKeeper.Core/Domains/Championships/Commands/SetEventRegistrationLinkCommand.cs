namespace CupKeeper.Domains.Championships.Commands;

public sealed class SetEventRegistrationLinkCommand : ExistingScheduledEventCommandBase
{
    public string? RegistrationLink { get; set; } = null!;
}
