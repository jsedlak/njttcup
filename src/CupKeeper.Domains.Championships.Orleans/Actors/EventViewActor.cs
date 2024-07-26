using CupKeeper.Domains.Championships.Events.ScheduledEvents;
using CupKeeper.Domains.Championships.ServiceModel;
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
    
    public EventViewActor(ILogger<EventViewActor> logger, IEventViewRepository viewRepository)
    {
        _logger = logger;
        _viewRepository = viewRepository;
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
        existing.RegistrationLink = ev.RegistrationLink;
        existing.UsacResultsLink = ev.UsacResultsLink;
        existing.UsacPermitNumber = ev.UsacPermitNumber;

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

    #region View Model: Results Loading
    private async Task Handle(EventResultsLoadedEvent ev)
    {
        
    }
    #endregion

    #region View Model: Results Manipulation
    private async Task Handle(CategoryResultAddedEvent ev)
    {
        
    }

    private async Task Handle(CategoryResultNameSetEvent ev)
    {
        
    }

    private async Task Handle(CategoryResultRemovedEvent ev)
    {
        
    }

    private async Task Handle(RiderResultAddedEvent ev)
    {
        
    }

    private async Task Handle(RiderResultMovedEvent ev)
    {
        
    }

    private async Task Handle(RiderResultRemovedEvent ev)
    {
        
    }
    #endregion
    
    #region View Model: Metadata

    private async Task Handle(EventCourseSetEvent ev)
    {
        
    }

    private async Task Handle(EventDatesSetEvent ev)
    {
        
    }

    private async Task Handle(EventNameSetEvent ev)
    {
        
    }

    private async Task Handle(EventRegistrationLinkSetEvent ev)
    {
        
    }

    private async Task Handle(EventUsacDataSetEvent ev)
    {
        
    }
    #endregion
}