using CupKeeper.Domains.Championships.Events.ScheduledEvents;
using CupKeeper.Domains.Championships.ServiceModel;
using Microsoft.Extensions.Logging;
using Orleans.Runtime;
using Orleans.Streams;

namespace CupKeeper.Domains.Championships.Actors;

[ImplicitStreamSubscription(ActorConstants.ScheduledEvent_EventStreamName)]
public class EventViewActor : Grain, IGrainWithGuidKey
{
    private readonly ILogger<EventViewActor> _logger;
    private readonly IEventViewWriteRepository _writeRepository;
    private StreamSubscriptionHandle<ScheduledEventBaseEvent>? _subscriptionHandle;
    
    public EventViewActor(ILogger<EventViewActor> logger, IEventViewWriteRepository writeRepository)
    {
        _logger = logger;
        _writeRepository = writeRepository;
    }
    
    #region Activation / Deactivation
    public override async Task OnActivateAsync(CancellationToken cancellationToken)
    {
        await base.OnActivateAsync(cancellationToken);

        IStreamProvider streamProvider = this.GetStreamProvider("StreamProvider"); // ServiceProvider.GetRequiredService<IStreamProvider>();

        var streamId = StreamId.Create(ActorConstants.ScheduledEvent_EventStreamName, this.GetPrimaryKey());
        IAsyncStream<ScheduledEventBaseEvent> stream = streamProvider.GetStream<ScheduledEventBaseEvent>(streamId);

        _subscriptionHandle = await stream.SubscribeAsync(OnNextAsync);
    }

    public override async Task OnDeactivateAsync(DeactivationReason reason, CancellationToken cancellationToken)
    {
        if (_subscriptionHandle is not null)
        {
            await _subscriptionHandle.UnsubscribeAsync();
        }

        await base.OnDeactivateAsync(reason, cancellationToken);
    }
    
    private async Task OnNextAsync(IList<SequentialItem<ScheduledEventBaseEvent>> items)
    {
        foreach (var item in items)
        {
            var @event = item.Item;
            
            _logger.LogInformation($"Captured event: {@event.GetType().Name}");

            try
            {
                dynamic o = this;
                dynamic e = @event;
                await o.Handle(e);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not handle event {@event.GetType().Name}");
            }
        }
    }
    #endregion

    #region View Model: Creation / Deletion
    private async Task Handle(ScheduledEventCreatedEvent ev)
    {
        var existing = await _writeRepository.GetAsync(ev.AggregateId) ?? new();

        existing.Name = ev.Name;
        existing.Id = ev.AggregateId;
        existing.VenueId = ev.VenueId;
        existing.CourseId = ev.CourseId;
        existing.ScheduledDate = ev.ScheduledDate;
        existing.RegistrationLink = ev.RegistrationLink;
        existing.UsacResultsLink = ev.UsacResultsLink;
        existing.UsacPermitNumber = ev.UsacPermitNumber;

        await _writeRepository.UpsertAsync(existing);
    }

    private async Task Handle(ScheduledEventDeletedEvent ev)
    {
        var existing = await _writeRepository.GetAsync(ev.AggregateId);

        if (existing is null)
        {
            return;
        }

        existing.IsDeleted = true;

        await _writeRepository.UpsertAsync(existing);
    }

    private async Task Handle(ScheduledEventRestoredEvent ev)
    {
        var existing = await _writeRepository.GetAsync(ev.AggregateId);

        if (existing is null)
        {
            return;
        }

        existing.IsDeleted = false;

        await _writeRepository.UpsertAsync(existing);
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