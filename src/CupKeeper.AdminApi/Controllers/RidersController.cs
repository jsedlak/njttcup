using CupKeeper.AdminApi.ApiModel;
using CupKeeper.Domains.Championships.Actors;
using CupKeeper.Domains.Championships.ServiceModel;
using Microsoft.AspNetCore.Mvc;

namespace CupKeeper.AdminApi.Controllers;

// TODO: Break this out into its own project (MICRO SERVICES!!)
[ApiController]
[Route("/api/riders")]
public class RidersController : Controller
{
    private readonly IEventViewRepository _eventViewRepository;
    private readonly IClusterClient _clusterClient;
    private readonly IRiderRepository _riderRepository;
    private readonly ILogger<RidersController> _logger;

    public RidersController(IClusterClient clusterClient, IRiderRepository riderRepository, IEventViewRepository eventViewRepository, ILogger<RidersController> logger)
    {
        _clusterClient = clusterClient;
        _riderRepository = riderRepository;
        _eventViewRepository = eventViewRepository;
        _logger = logger;
    }

    [HttpPost("{riderId}/name")]
    public async Task SetRiderName([FromRoute] Guid riderId, [FromBody] SetRiderNameRequest request)
    {
        // update the rider
        var rider = await _riderRepository.GetAsync(riderId);
        rider.Name = request.Name;
        await _riderRepository.UpdateAsync(rider);
        
        // process the change
        // TODO: Move this to a service or something?
        var queryable = await _eventViewRepository.QueryAsync();
        var foundEvents = queryable.ToArray();
        
        _logger.LogInformation($"Event Count: {foundEvents.Length}");
            
        var affectedEvents = foundEvents
            .Where(m => m.Results.Any(c => c.Riders.Any(r => r.RiderId == riderId)))
            .ToArray();

        _logger.LogInformation($"Found {affectedEvents.Count()} events for rider {riderId}");
        
        List<Task> tasks = [];
        foreach (var @event in affectedEvents)
        {
            var eventActor =_clusterClient.GetGrain<IEventActor>(@event.Id);
            tasks.Add(eventActor.ReloadRiderData(riderId));
        }

        // wait for all the changes to propagate
        await Task.WhenAll(tasks);
    }
}