namespace CupKeeper.Domains.Championships.Commands;

public sealed class AddRiderResultCommand : ExistingScheduledEventCommandBase
{
    public Guid CategoryResultId { get; set; }

    public Guid RiderId { get; set; }

    public int Position { get; set; }

    public string? Team { get; set; }

    public string? LicenseNumber { get; set; }

    public string? UsacCategory { get; set; }

    public string? Time { get; set; }

    public string? Points { get; set; }
}
