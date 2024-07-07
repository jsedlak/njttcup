using CupKeeper.Domains.Championships.Commands.EventResults;
using CupKeeper.Domains.Championships.Model.Parsing;
using Microsoft.Extensions.Logging;
using Orleans.SyncWork;
using Orleans.SyncWork.Enums;

namespace CupKeeper.Domains.Championships.Actors;

public class EventResultsActor : SyncWorker<LoadResultsCommand, ParsedEventResult>, IEventResultsActor {
    public EventResultsActor(ILogger logger, LimitedConcurrencyLevelTaskScheduler limitedConcurrencyScheduler) 
        : base(logger, limitedConcurrencyScheduler)
    {
    }

    protected override Task<ParsedEventResult> PerformWork(LoadResultsCommand request, GrainCancellationToken grainCancellationToken)
    {
        throw new NotImplementedException();
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