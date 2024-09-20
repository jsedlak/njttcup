using Newtonsoft.Json;
using Websocket.Client;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CupKeeper.PubSub;

public class AzureSubClient : ISubClient, IDisposable
{
    private readonly WebsocketClient _client;
    private Action<object>? _onMessage = null;
    
    public AzureSubClient(string uri)
    {
        _client = new WebsocketClient(new Uri(uri));
        _client.ReconnectTimeout = null;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (IsDisposed)
        {
            return;
        }
        
        _client.Dispose();

        if (disposing)
        {
            GC.SuppressFinalize(this);
        }

        IsDisposed = true;
    }
    
    public async Task SubscribeAsync(Action<object> onMessage)
    {
        _onMessage = onMessage;
        _client.MessageReceived.Subscribe(msg =>
        {
            Console.WriteLine($"Message Received: {msg.MessageType}");
            // Console.WriteLine();
            
            var envelope = JsonSerializer.Deserialize<PubSubEnvelope>(msg.Text!);
            var messageType = Type.GetType(envelope!.MessageType)!;

            if (messageType == null)
            {
                Console.WriteLine("Message type is null, cannot deserialize");
                return;
            }

            Console.WriteLine($"{envelope.Message}");
            Console.WriteLine($"Message Type is {messageType?.Name ?? "NULL"}");
            try
            {
                var messageObject = JsonConvert.DeserializeObject(envelope.Message, messageType!);
                // JsonSerializer.Deserialize(envelope.Message, messageType);

                if (messageObject == null)
                {
                    Console.WriteLine("Message is null");
                    return;
                }

                Console.WriteLine("Sending message to callback");
                _onMessage(messageObject);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deserializing");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            

            
        });
        
        await _client.Start();
    }

    public void Dispose()
    {
        Dispose(true);
    }

    public bool IsDisposed { get; private set; }
    
}