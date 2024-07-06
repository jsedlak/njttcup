using CupKeeper.Domains.Championships.Model.Parsing;

namespace CupKeeper.Domains.Championships.ServiceModel;

public interface IResultsLoader
{
    Task<ParsedEventResult> GetResults(string raceIdentifier);
}