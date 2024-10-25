using CupKeeper.Domains.Championships.Events.Leaderboards;
using CupKeeper.Domains.Championships.Model;
using CupKeeper.Domains.Championships.ServiceModel;
using CupKeeper.Domains.Championships.ViewModel;
using CupKeeper.Domains.Locations.ServiceModel;
using CupKeeper.PubSub;
using Microsoft.Extensions.Logging;
using Orleans.Streams;
using Orleans.Streams.Core;

namespace CupKeeper.Domains.Championships.Actors;

[ImplicitStreamSubscription(ActorConstants.LeaderboardEventStreamName)]
public class LeaderboardSearchViewModelActor :
    Grain,
    ILeaderboardSearchViewModelActor,
    IStreamSubscriptionObserver,
    IAsyncObserver<LeaderboardBaseEvent>
{
    private readonly ILogger<LeaderboardSearchViewModelActor> _logger;
    private readonly ILeaderboardViewRepository _leaderboardViewRepository;
    private readonly IEventViewRepository _viewRepository;
    private readonly IRiderLocatorService _riderLocatorService;
    private readonly IVenueViewRepository _venueViewRepository;

    private readonly IPubClient _pubClient;

    public LeaderboardSearchViewModelActor(ILogger<LeaderboardSearchViewModelActor> logger, IEventViewRepository viewRepository,
        IRiderLocatorService riderLocatorService, IVenueViewRepository venueViewRepository, IPubClient pubClient,
        ILeaderboardViewRepository leaderboardViewRepository)
    {
        _logger = logger;
        _viewRepository = viewRepository;
        _riderLocatorService = riderLocatorService;
        _venueViewRepository = venueViewRepository;
        _pubClient = pubClient;
        _leaderboardViewRepository = leaderboardViewRepository;
    }

    #region Implicit Subscription Management

    public async Task OnSubscribed(IStreamSubscriptionHandleFactory handleFactory)
    {
        var handle = handleFactory.Create<LeaderboardBaseEvent>();
        await handle.ResumeAsync(this);
    }

    public async Task OnNextAsync(LeaderboardBaseEvent item, StreamSequenceToken? token = null)
    {
        _logger.LogInformation("OnNextAsync");

        _logger.LogInformation($"Captured event: {item.GetType().Name}");

        try
        {
            dynamic o = this;
            dynamic e = item;
            await o.Handle(e);

            await _pubClient.PublishAsync("events", item);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Could not handle event {item.GetType().Name}");
        }
    }

    public Task OnCompletedAsync()
    {
        _logger.LogInformation("OnCompletedAsync");
        return Task.CompletedTask;
    }

    public Task OnErrorAsync(Exception ex)
    {
        _logger.LogInformation("OnErrorAsync");
        return Task.CompletedTask;
    }

    #endregion

    private async Task Handle(LeaderboardCreatedEvent ev)
    {
        var existing = await _leaderboardViewRepository.GetAsync(ev.AggregateId) ?? new();
        
        existing.Id = ev.AggregateId;
        existing.Year = ev.Year;
        existing.Id = ev.AggregateId;

        await _leaderboardViewRepository.UpsertAsync(existing);
    }

    private async Task Handle(LeaderboardDeletedEvent ev)
    {
        var existing = await _leaderboardViewRepository.GetAsync(ev.AggregateId) ?? new();

        existing.Id = ev.AggregateId;
        existing.IsDeleted = true;

        await _leaderboardViewRepository.UpsertAsync(existing);
    }

    private async Task Handle(LeaderboardUndeletedEvent ev)
    {
        var existing = await _leaderboardViewRepository.GetAsync(ev.AggregateId) ?? new();

        existing.Id = ev.AggregateId;
        existing.IsDeleted = false;

        await _leaderboardViewRepository.UpsertAsync(existing);
    }

    private async Task Handle(LeaderboardPublishedEvent ev)
    {
        var existing = await _leaderboardViewRepository.GetAsync(ev.AggregateId) ?? new();

        existing.Id = ev.AggregateId;
        existing.IsPublished = true;

        await _leaderboardViewRepository.UpsertAsync(existing);
    }

    private async Task Handle(LeaderboardUnpublishedEvent ev)
    {
        var existing = await _leaderboardViewRepository.GetAsync(ev.AggregateId) ?? new();

        existing.Id = ev.AggregateId;
        existing.IsPublished = false;

        await _leaderboardViewRepository.UpsertAsync(existing);
    }

    private async Task Handle(LeaderboardRecalculatedEvent ev)
    {
        _logger.LogInformation($"Handling recalc event in view actor for {ev.AggregateId}");
        
        var existing = await _leaderboardViewRepository.GetAsync(ev.AggregateId) ?? new();
        
        var allRiderIds = ev.Categories.SelectMany(m => m.Riders).Select(m => m.RiderId).Distinct();
        var riders = new List<Rider>();
        
        foreach (var riderId in allRiderIds)
        {
            var found = await _riderLocatorService.GetAsync(riderId);
            riders.Add(found);
        }
        
        existing.Id = ev.AggregateId;
        existing.Year = ev.Year;
        existing.Events = ev.EventResultIds;
        
        existing.Categories = ev.Categories.Select(c =>
        {
            return new CategoryLeaderboardViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Order = c.Order,
                Riders = c.Riders.Select(r => new RiderLeaderboardPlacingViewModel
                {
                    RiderId = r.Id,
                    Name = riders.First(m => m.Id == r.RiderId).Name,
                    Team = riders.First(m => m.Id == r.RiderId).TeamName ?? "",
                    Id = r.Id,
                    Points = r.Points,
                    RawTotal = r.RawTotal,
                    Total = r.Total
                }).ToArray()
            };
        }).ToArray();

        await _leaderboardViewRepository.UpsertAsync(existing);
    }
}