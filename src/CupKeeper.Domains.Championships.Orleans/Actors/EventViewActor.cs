using CupKeeper.Domains.Championships.Events.ScheduledEvents;
using Microsoft.Extensions.Logging;
using Orleans.Runtime;
using Orleans.Streams;

namespace CupKeeper.Domains.Championships.Actors;

[ImplicitStreamSubscription(ActorConstants.ScheduledEvent_EventStreamName)]
public class EventViewActor : Grain, IGrainWithGuidKey
{
    private readonly ILogger<EventViewActor> _logger;
    private StreamSubscriptionHandle<ScheduledEventBaseEvent> _subscriptionHandle;
    
    public EventViewActor(ILogger<EventViewActor> logger)
    {
        _logger = logger;
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
        await _subscriptionHandle.UnsubscribeAsync();
        
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

    
}