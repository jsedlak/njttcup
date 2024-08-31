namespace CupKeeper.Domains.Championships.Commands;

[GenerateSerializer]
public sealed class AddRiderResultCommand : ExistingScheduledEventCommandBase
{
    public AddRiderResultCommand(Guid scheduledEventId) 
        : base(scheduledEventId)
    {
    }
    
    [Id(0)]
    public Guid CategoryResultId { get; set; }

    [Id(1)]
    public Guid RiderId { get; set; }

    [Id(2)]
    public int Position { get; set; }

    [Id(3)]
    public string? Team { get; set; }

    [Id(4)]
    public string? LicenseNumber { get; set; }

    [Id(5)]
    public string? UsacCategory { get; set; }

    [Id(6)]
    public double? Time { get; set; }

    [Id(7)]
    public int? Points { get; set; }
}