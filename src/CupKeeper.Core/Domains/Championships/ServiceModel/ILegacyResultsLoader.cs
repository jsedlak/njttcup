using CupKeeper.Domains.Championships.Model.Parsing;

namespace CupKeeper.Domains.Championships.ServiceModel;

public interface ILegacyResultsLoader
{
    Task<ParsedEventResult> GetResults(string json);
}