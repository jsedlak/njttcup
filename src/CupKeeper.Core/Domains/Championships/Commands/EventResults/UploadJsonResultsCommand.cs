namespace CupKeeper.Domains.Championships.Commands.EventResults;

[GenerateSerializer]
public class UploadJsonResultsCommand
{
    public UploadJsonResultsCommand(Guid eventId)
    {
        EventId = eventId;
    }

    /// <summary>
    /// Gets or Sets the event identifier
    /// </summary>
    [Id(0)]
    public Guid EventId { get; set; }

    /// <summary>
    /// Gets or Sets the JSON to upload and parse
    /// </summary>
    [Id(1)]
    public string Json { get; set; } = null!;
}