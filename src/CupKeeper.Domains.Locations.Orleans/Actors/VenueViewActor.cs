using CupKeeper.Domains.Locations.Events;
using CupKeeper.Domains.Locations.ServiceModel;
using CupKeeper.Domains.Locations.ViewModel;
using Microsoft.Extensions.Logging;
using Orleans.Streams;
using Orleans.Streams.Core;

namespace CupKeeper.Domains.Locations.Actors;

[ImplicitStreamSubscription(ActorConstants.VenueEventEventStreamName)]
public class VenueViewActor : Grain, IVenueViewActor,
    IStreamSubscriptionObserver, IAsyncObserver<VenueBaseEvent>
{
    private readonly ILogger<VenueViewActor> _logger;
    private readonly IVenueViewRepository _viewRepository;

    public VenueViewActor(ILogger<VenueViewActor> logger, IVenueViewRepository viewRepository)
    {
        _logger = logger;
        _viewRepository = viewRepository;
    }

    #region Subscription Management
    public async Task OnSubscribed(IStreamSubscriptionHandleFactory handleFactory)
    {
        var handle = handleFactory.Create<VenueBaseEvent>();
        await handle.ResumeAsync(this);
    }

    public async Task OnNextAsync(VenueBaseEvent item, StreamSequenceToken? token = null)
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
    
    #region Event Handling

    private async Task Handle(VenueCreatedEvent ev)
    {
        var existing = await _viewRepository.GetAsync(ev.AggregateId) ?? new();

        existing.Name = ev.Name;
        existing.ParkingAddress = ev.ParkingAddress;

        await _viewRepository.UpsertAsync(existing);
    }
    
    private async Task Handle(VenueDeletedEvent ev)
    {
        var existing = await _viewRepository.GetAsync(ev.AggregateId);

        if (existing is null)
        {
            return;
        }

        existing.IsDeleted = true;

        await _viewRepository.UpsertAsync(existing);
    }

    private async Task Handle(VenueNameSetEvent ev)
    {
        var existing = await _viewRepository.GetAsync(ev.AggregateId);

        if (existing is null)
        {
            return;
        }

        existing.Name = ev.Name;

        await _viewRepository.UpsertAsync(existing);
    }

    private async Task Handle(VenueParkingAddressSetEvent ev)
    {
        var existing = await _viewRepository.GetAsync(ev.AggregateId);

        if (existing is null)
        {
            return;
        }

        existing.ParkingAddress = ev.ParkingAddress;

        await _viewRepository.UpsertAsync(existing);
    }

    private async Task Handle(CourseAddedToVenueEvent ev)
    {
        var existing = await _viewRepository.GetAsync(ev.AggregateId);

        if (existing is null)
        {
            return;
        }

        existing.Courses = existing.Courses.Union([
            new CourseViewModel
            {
                Id = ev.CourseId,
                Name = ev.Name,
                Description = ev.Description,
                RouteLink = ev.RouteLink,
                RideWithGpsId = ev.RideWithGpsId,
                Mileage = ev.Mileage,
                Address = ev.Address
            }
        ]);

        await _viewRepository.UpsertAsync(existing);
    }

    private async Task Handle(CourseAddressSetEvent ev)
    {
        var existing = await _viewRepository.GetAsync(ev.AggregateId);

        if (existing is null)
        {
            return;
        }

        var course = existing.Courses.First(m => m.Id == ev.CourseId);
        course.Address = ev.Address;
        
        await _viewRepository.UpsertAsync(existing);
    }

    private async Task Handle(CourseDeletedFromVenueEvent ev)
    {
        var existing = await _viewRepository.GetAsync(ev.AggregateId);

        if (existing is null)
        {
            return;
        }

        var course = existing.Courses.First(m => m.Id == ev.CourseId);
        course.IsDeleted = true;
        
        await _viewRepository.UpsertAsync(existing);
    }

    private async Task Handle(CourseMetaDataSetEvent ev)
    {
        var existing = await _viewRepository.GetAsync(ev.AggregateId);

        if (existing is null)
        {
            return;
        }

        var course = existing.Courses.First(m => m.Id == ev.CourseId);
        course.Name = ev.Name;
        course.Description = ev.Description;
        
        await _viewRepository.UpsertAsync(existing);
    }

    private async Task Handle(CourseRouteDataSetEvent ev)
    {
        var existing = await _viewRepository.GetAsync(ev.AggregateId);

        if (existing is null)
        {
            return;
        }

        var course = existing.Courses.First(m => m.Id == ev.CourseId);
        course.RouteLink = ev.RouteLink;
        course.RideWithGpsId = ev.RideWithGpsId;
        course.Mileage = ev.Mileage;
        
        await _viewRepository.UpsertAsync(existing);
    }
    #endregion
}