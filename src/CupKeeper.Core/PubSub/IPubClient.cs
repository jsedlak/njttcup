namespace CupKeeper.PubSub;

public interface IPubClient
{
    Task PublishAsync<TMessage>(string group, TMessage message);
}