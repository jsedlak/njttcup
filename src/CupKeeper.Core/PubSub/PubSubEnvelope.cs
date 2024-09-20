namespace CupKeeper.PubSub;

public class PubSubEnvelope
{
    public string MessageType { get; set; } = null;
    
    public string Message { get; set; } = null;
}