using CupKeeper.Domains.Championships.Events.ScheduledEvents;

namespace CupKeeper.Domains.Championships.Commands.EventResults;

[GenerateSerializer]
public class LoadResultsCommand
{
    public LoadResultsCommand(string usacPermitNumber)
    {
        UsacPermitNumber = usacPermitNumber;
    }
    
    /// <summary>
    /// Gets or Sets the USAC Permit Number to load results from
    /// </summary>
    [Id(0)]
    public string UsacPermitNumber { get; set; }
}