using System.Text.Json;
using Websocket.Client;

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
    
    public Task SubscribeAsync(Action<object> onMessage)
    {
        _onMessage = onMessage;
        _client.MessageReceived.Subscribe(msg =>
        {
            Console.WriteLine($"Message Received: {msg.MessageType}");
            // Console.WriteLine();
            
            var envelope = JsonSerializer.Deserialize<PubSubEnvelope>(msg.Text!);
            var messageType = Type.GetType(envelope!.MessageType)!;

            Console.WriteLine($"{messageType}");
            Console.WriteLine($"{envelope.Message}");
            
            var messageObject = JsonSerializer.Deserialize(envelope.Message, messageType);
            
            if (messageObject == null)
            {
                Console.WriteLine("Message is null");
                return;
            }
            
            onMessage(messageObject);
        });
        
        return _client.Start();
    }

    public void Dispose()
    {
        Dispose(true);
    }

    public bool IsDisposed { get; private set; }
    
}