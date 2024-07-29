using CupKeeper.Domains.Championships.Commands.EventResults;
using CupKeeper.Domains.Championships.Model.Parsing;
using CupKeeper.Domains.Championships.ServiceModel;
using CupKeeper.Domains.Championships.Services;
using Microsoft.Extensions.Logging;
using Orleans.SyncWork;
using Orleans.SyncWork.Enums;

namespace CupKeeper.Domains.Championships.Actors;

public class EventResultsActor : SyncWorker<LoadResultsCommand, ParsedEventResult>, IEventResultsActor {
    private readonly IResultsLoader _resultsLoader;

    public EventResultsActor(IResultsLoader resultsLoader, ILogger<EventResultsActor> logger, LimitedConcurrencyLevelTaskScheduler limitedConcurrencyScheduler) 
        : base(logger, limitedConcurrencyScheduler)
    {
        _resultsLoader = resultsLoader;
    }

    protected override Task<ParsedEventResult> PerformWork(LoadResultsCommand request, GrainCancellationToken grainCancellationToken)
    {
        return _resultsLoader.GetResults(request.UsacPermitNumber);
    }

    public async ValueTask<bool> StartLoad(LoadResultsCommand command)
    {
        var result = await base.Start(command);
        return result;
    }

    public async ValueTask<bool> CheckStatus()
    {
        var status = await base.GetWorkStatus();
        return status is SyncWorkStatus.Completed or SyncWorkStatus.Faulted;
    }

    public async Task<ParsedEventResult?> GetResults()
    {
        return await base.GetResult();
    }
}