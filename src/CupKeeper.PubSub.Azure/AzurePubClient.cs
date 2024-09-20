using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Messaging.WebPubSub;
using Newtonsoft.Json;

namespace CupKeeper.PubSub;

public class AzurePubClient : IPubClient
{
    private readonly WebPubSubServiceClient _client;

    public AzurePubClient(WebPubSubServiceClient client)
    {
        _client = client;
    }

    public Task PublishAsync(string group, object message)
    {
        var envelope = new PubSubEnvelope
        {
            MessageType = message.GetType().AssemblyQualifiedName!,
            Message =  JsonConvert.SerializeObject(message) // JsonSerializer.Serialize(message)
        };
        
        var content = RequestContent.Create(envelope);
  
        return _client.SendToGroupAsync(
            group, 
            content, 
            ContentType.ApplicationJson
        );
    }
}