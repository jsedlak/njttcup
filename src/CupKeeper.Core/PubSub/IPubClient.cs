namespace CupKeeper.PubSub;

public interface IPubClient
{
    Task PublishAsync(string group, object message);
}