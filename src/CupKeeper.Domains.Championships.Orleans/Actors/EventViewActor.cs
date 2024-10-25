using CupKeeper.Domains.Championships.Events.ScheduledEvents;
using CupKeeper.Domains.Championships.Messages;
using CupKeeper.Domains.Championships.Model;
using CupKeeper.Domains.Championships.ServiceModel;
using CupKeeper.Domains.Championships.ViewModel;
using CupKeeper.Domains.Locations.ServiceModel;
using CupKeeper.PubSub;
using Microsoft.Extensions.Logging;
using Orleans.Runtime;
using Orleans.Streams;
using Orleans.Streams.Core;

namespace CupKeeper.Domains.Championships.Actors;

[ImplicitStreamSubscription(ActorConstants.ScheduledEventEventStreamName)]
public class EventViewActor : Grain, IEventSearchViewModelActor,
    IStreamSubscriptionObserver, IAsyncObserver<ScheduledEventBaseEvent>
{
    private readonly ILogger<EventViewActor> _logger;
    private readonly IEventViewRepository _viewRepository;
    private readonly IRiderLocatorService _riderLocatorService;
    private readonly IVenueViewRepository _venueViewRepository;

    private readonly IPubClient _pubClient;
    
    public EventViewActor(ILogger<EventViewActor> logger, IEventViewRepository viewRepository, IRiderLocatorService riderLocatorService, IVenueViewRepository venueViewRepository, IPubClient pubClient)
    {
        _logger = logger;
        _viewRepository = viewRepository;
        _riderLocatorService = riderLocatorService;
        _venueViewRepository = venueViewRepository;
        _pubClient = pubClient;
    }
    
    #region Implicit Subscription Management
    public async Task OnSubscribed(IStreamSubscriptionHandleFactory handleFactory)
    {
        var handle = handleFactory.Create<ScheduledEventBaseEvent>();
        await handle.ResumeAsync(this);
    }
    
    public async Task OnNextAsync(ScheduledEventBaseEvent item, StreamSequenceToken? token = null)
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

    #region View Model: Creation / Deletion
    private async Task Handle(ScheduledEventCreatedEvent ev)
    {
        var existing = await _viewRepository.GetAsync(ev.AggregateId) ?? new();

        existing.Name = ev.Name;
        existing.Id = ev.AggregateId;
        existing.VenueId = ev.VenueId;
        existing.CourseId = ev.CourseId;
        existing.ScheduledDate = ev.ScheduledDate;
        existing.ChampionshipYear = ev.ScheduledDate.GetValueOrDefault().Year;
        existing.RegistrationLink = ev.RegistrationLink;
        existing.UsacResultsLink = ev.UsacResultsLink;
        existing.UsacPermitNumber = ev.UsacPermitNumber;
        
        var venue = await _venueViewRepository.GetAsync(ev.VenueId);
        var course = venue?.Courses.FirstOrDefault(m => m.Id == ev.CourseId);
        
        // TODO: Return error if we can't find the venue?
        existing.VenueName = venue?.Name;
        existing.CourseName = course?.Name;

        await _viewRepository.UpsertAsync(existing);
    }

    private async Task Handle(ScheduledEventDeletedEvent ev)
    {
        var existing = await _viewRepository.GetAsync(ev.AggregateId);

        if (existing is null)
        {
            return;
        }

        existing.IsDeleted = true;

        await _viewRepository.UpsertAsync(existing);
    }

    private async Task Handle(ScheduledEventRestoredEvent ev)
    {
        var existing = await _viewRepository.GetAsync(ev.AggregateId);

        if (existing is null)
        {
            return;
        }

        existing.IsDeleted = false;

        await _viewRepository.UpsertAsync(existing);
    }
    #endregion

    #region View Model: Publishing
    private async Task Handle(EventResultsPublishedEvent ev)
    {
        var existing = await _viewRepository.GetAsync(ev.AggregateId) ?? new();
        existing.IsPublished = true;
        await _viewRepository.UpsertAsync(existing);
    }
    #endregion

    #region View Model: Results Loading
    private async Task Handle(EventResultsLoadedEvent ev)
    {
        var existing = await _viewRepository.GetAsync(ev.AggregateId) ?? new();
        
        var categories = new List<CategoryResultViewModel>();

        // we need to build view models for every category
        foreach (var cat in ev.Categories)
        {
            var categoryView = new CategoryResultViewModel()
            {
                Id = cat.Id,
                Order = cat.Order,
                Name = cat.Name
            };
            
            var riderList = new List<RiderResultViewModel>();

            // and call out for rider names
            // TODO: Can we parallel or batch this for performance?
            foreach (var rider in cat.Riders)
            {
                var riderReference = await _riderLocatorService.GetAsync(rider.RiderId);

                riderList.Add(new RiderResultViewModel
                {
                    Id = rider.Id,
                    Place = rider.Place,
                    Points = rider.Points,
                    RiderId = rider.RiderId,
                    RiderName = riderReference.Name,
                    TeamName = rider.TeamName,
                    Time = rider.Time,
                    ExcludeFromPoints = rider.ExcludeFromPoints,
                    ExclusionReason = rider.ExclusionReason
                });
            }

            // build the two lists out yay
            categoryView.Riders = riderList.Where(m => !m.ExcludeFromPoints).ToArray();
            categoryView.ExcludedRiders = riderList.Where(m => m.ExcludeFromPoints).ToArray();
            
            categories.Add(categoryView);
        }

        existing.Results = categories.ToArray();

        await _viewRepository.UpsertAsync(existing);
    }
    #endregion

    #region View Model: Results Manipulation
    private async Task Handle(CategoryResultAddedEvent ev)
    {
        var existing = await _viewRepository.GetAsync(ev.AggregateId) ?? new();

        existing.Results = new List<CategoryResultViewModel>([
                ..existing.Results, 
                new CategoryResultViewModel()
                {
                    Id = ev.CategoryId, Name = ev.Name, Order = ev.Order 
                    
                }
            ])
            .OrderBy(o => o.Order)
            .ToArray();
        
        await _viewRepository.UpsertAsync(existing);
    }

    private async Task Handle(CategoryResultNameSetEvent ev)
    {
        var existing = await _viewRepository.GetAsync(ev.AggregateId) ?? new();
        
        var category = existing.Results.First(m => m.Id == ev.CategoryResultId);
        
        category.Name = ev.Name;
        category.Order = ev.Order;
        
        await _viewRepository.UpsertAsync(existing);
    }

    private async Task Handle(CategoryResultRemovedEvent ev)
    {
        var existing = await _viewRepository.GetAsync(ev.AggregateId) ?? new();
        
        existing.Results = existing.Results.Where(m => m.Id != ev.CategoryResultId).ToArray();
        
        await _viewRepository.UpsertAsync(existing);
    }

    private async Task Handle(RiderResultAddedEvent ev)
    {
        var existing = await _viewRepository.GetAsync(ev.AggregateId) ?? new();
        
        var category = existing.Results.First(m => m.Id == ev.CategoryResultId);
        
        category.Riders = new List<RiderResultViewModel>(
            [
                ..category.Riders,
                new RiderResultViewModel()
                {
                    RiderId = ev.RiderId,
                    Place = ev.Place,
                    TeamName = ev.Team,
                    Time = ev.Time,
                    Points = ev.Points,
                }
            ])
            .OrderBy(m => m.Place)
            .ToArray();
        
        await _viewRepository.UpsertAsync(existing);
    }

    private async Task Handle(RiderResultMovedEvent ev)
    {
        var existing = await _viewRepository.GetAsync(ev.AggregateId) ?? new();
        
        // get the two categories
        var sourceCategory = existing.Results.First(m => m.Id == ev.SourceCategoryResultId);
        var targetCategory = existing.Results.First(m => m.Id == ev.TargetCategoryResultId);
        
        // find the rider
        var rider = sourceCategory.Riders.First(m => m.Id == ev.RiderResultId);
        
        // move the rider!
        sourceCategory.Riders = sourceCategory.Riders.Where(m => m.RiderId != ev.RiderResultId).ToArray();
        targetCategory.Riders = targetCategory.Riders.Union([rider]).OrderBy(m => m.Place).ToArray();
        
        await _viewRepository.UpsertAsync(existing);
    }

    private async Task Handle(RiderResultRemovedEvent ev)
    {
        var existing = await _viewRepository.GetAsync(ev.AggregateId) ?? new();
        
        var category = existing.Results.First(m => m.Id == ev.CategoryResultId);
        category.Riders = category.Riders.Where(m => m.Id != ev.RiderResultId).ToArray();
        
        await _viewRepository.UpsertAsync(existing);
    }
    #endregion
    
    #region View Model: Metadata
    /// <summary>
    /// Handles when the venue & course have been set
    /// </summary>
    /// <param name="ev"></param>
    private async Task Handle(EventCourseSetEvent ev)
    {
        var existing = await _viewRepository.GetAsync(ev.AggregateId) ?? new();
        
        existing.VenueId = ev.VenueId;
        existing.CourseId = ev.CourseId;
        
        var venue = await _venueViewRepository.GetAsync(ev.VenueId);
        var course = venue?.Courses.FirstOrDefault(m => m.Id == ev.CourseId);
        
        // TODO: Return error if we can't find the venue?
        existing.VenueName = venue?.Name;
        existing.CourseName = course?.Name;
        
        await _viewRepository.UpsertAsync(existing);
    }

    /// <summary>
    /// Handles when the event's scheduled date has been set
    /// </summary>
    /// <param name="ev"></param>
    private async Task Handle(EventDatesSetEvent ev)
    {
        var existing = await _viewRepository.GetAsync(ev.AggregateId) ?? new();
        
        existing.ScheduledDate = ev.ScheduledDate;
        existing.ActualDate = ev.ActualDate;
        existing.ChampionshipYear = ev.ScheduledDate.GetValueOrDefault().Year;
        
        await _viewRepository.UpsertAsync(existing);
    }

    /// <summary>
    /// Handles setting the name on the event
    /// </summary>
    /// <param name="ev"></param>
    private async Task Handle(EventNameSetEvent ev)
    {
        var existing = await _viewRepository.GetAsync(ev.AggregateId) ?? new();
        
        existing.Name = ev.Name;
        
        await _viewRepository.UpsertAsync(existing);
    }

    /// <summary>
    /// Handles when the registration link has been set
    /// </summary>
    /// <param name="ev"></param>
    private async Task Handle(EventRegistrationLinkSetEvent ev)
    {
        var existing = await _viewRepository.GetAsync(ev.AggregateId) ?? new();
        
        existing.RegistrationLink = ev.RegistrationLink;
        
        await _viewRepository.UpsertAsync(existing);
    }

    /// <summary>
    /// Handles when the USAC data has been set
    /// </summary>
    /// <param name="ev"></param>
    private async Task Handle(EventUsacDataSetEvent ev)
    {
        var existing = await _viewRepository.GetAsync(ev.AggregateId) ?? new();
        
        existing.UsacResultsLink = ev.UsacResultsLink;
        existing.UsacPermitNumber = ev.UsacPermitNumber;
        
        await _viewRepository.UpsertAsync(existing);
    }
    #endregion
    
    #region View Model: Hydration Management
    private async Task Handle(ReloadRiderRequest request)
    {
        var existing = await _viewRepository.GetAsync(request.AggregateId) ?? new();
        
        // get the rider
        var rider = await _riderLocatorService.GetAsync(request.RiderId);

        foreach (var categoryResult in existing.Results)
        {
            var riderResults = categoryResult.Riders.Where(m => m.RiderId == request.RiderId).ToArray();
            foreach (var riderResult in riderResults)
            {
                riderResult.RiderName = rider.Name;
            }
        }
        
        await _viewRepository.UpsertAsync(existing);
    }
    #endregion
}