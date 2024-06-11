namespace CupKeeper.Domains.Championships.Commands;

[GenerateSerializer]
public sealed class SetEventRegistrationLinkCommand : ExistingScheduledEventCommandBase
{
    public SetEventRegistrationLinkCommand(Guid scheduledEventId) 
        : base(scheduledEventId)
    {
    }
    
    [Id(0)]
    public string? RegistrationLink { get; set; } = null!;
}
