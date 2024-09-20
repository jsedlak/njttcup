using Azure.Messaging.WebPubSub;
using CupKeeper.WebApi;
using Microsoft.AspNetCore.Mvc;

namespace CupKeeper.AdminApi.Controllers;

[ApiController]
[Route("/api/pubsub")]
public class PubSubController : Controller
{
    private readonly WebPubSubServiceClient _webPubSubServiceClient;

    public PubSubController(WebPubSubServiceClient webPubSubServiceClient)
    {
        _webPubSubServiceClient = webPubSubServiceClient;
    }

    [HttpGet("groups/{group}/subscribe")]
    public async Task<ApiResult<string>> SubscribeAsync([FromRoute]string group)
    {
        var result = await _webPubSubServiceClient.GetClientAccessUriAsync(TimeSpan.FromDays(1), "system", [], [group], CancellationToken.None);
        return new ApiResult<string> { Data = result.ToString() };
    }
}