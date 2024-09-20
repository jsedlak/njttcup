using CupKeeper.PubSub;
using CupKeeper.WebApi;

namespace CupKeeper.AdminApp.Services;

public class PubSubServiceFactory : ApiServiceBase
{
    public PubSubServiceFactory(IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
    }

    public async Task<ISubClient> CreateClient(string group)
    {
        var connectionUri = await GetAsync<ApiResult<string>>($"api/pubsub/groups/{group}/subscribe");
        
        Console.WriteLine($"Connection URI: {connectionUri.Data}");
        
        return new AzureSubClient(connectionUri.Data);
    }
}