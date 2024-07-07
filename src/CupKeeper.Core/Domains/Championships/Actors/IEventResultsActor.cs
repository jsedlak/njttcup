using CupKeeper.Domains.Championships.Commands.EventResults;
using CupKeeper.Domains.Championships.Model.Parsing;

namespace CupKeeper.Domains.Championships.Actors;

public interface IEventResultsActor : IGrainWithStringKey
{
    ValueTask<bool> StartLoad(LoadResultsCommand command);

    ValueTask<bool> CheckStatus();

    Task<ParsedEventResult?> GetResults();
}