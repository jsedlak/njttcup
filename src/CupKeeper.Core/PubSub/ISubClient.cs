namespace CupKeeper.PubSub;

public interface ISubClient
{
    Task SubscribeAsync(Action<object> onMessage);
}