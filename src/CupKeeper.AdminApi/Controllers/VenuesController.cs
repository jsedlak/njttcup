using CupKeeper.Cqrs;
using CupKeeper.Domains.Locations.Actors;
using CupKeeper.Domains.Locations.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CupKeeper.AdminApi.Controllers;

[ApiController]
[Route("/api/venues")]
public class VenuesController : Controller
{
    private readonly IClusterClient _clusterClient;

    public VenuesController(IClusterClient clusterClient)
    {
        _clusterClient = clusterClient;
    }

    #region Venue Management
    [HttpPost]
    public async Task<CommandResult> CreateVenueAsync([FromBody] CreateVenueCommand command)
    {
        var newVenueId = Guid.NewGuid();
        var actor = _clusterClient.GetGrain<IVenueActor>(newVenueId);

        return await actor.Create(command);
    }

    [HttpDelete("{venueId}")]
    public async Task<CommandResult> DeleteVenueAsync([FromRoute] Guid venueId)
    {
        var actor = _clusterClient.GetGrain<IVenueActor>(venueId);

        return await actor.Delete(new DeleteVenueCommand(venueId));
    }

    [HttpPost("{venueId}/name")]
    public async Task<CommandResult> SetVenueNameAsync([FromRoute] Guid venueId, [FromBody]SetVenueNameCommand command)
    {
        var actor = _clusterClient.GetGrain<IVenueActor>(venueId);

        return await actor.SetName(command);
    }

    [HttpPost("{venueId}/address")]
    public async Task<CommandResult> SetParkingAddressAsync([FromRoute] Guid venueId, [FromBody]SetVenueParkingAddressCommand command)
    {
        var actor = _clusterClient.GetGrain<IVenueActor>(venueId);

        return await actor.SetParkingAddress(command);
    }
    #endregion

    #region Course Management
    [HttpPost("{venueId}/courses")]
    public async Task<CommandResult> AddCourseAsync([FromRoute] Guid venueId, [FromBody]AddCourseToVenueCommand command)
    {
        var actor = _clusterClient.GetGrain<IVenueActor>(venueId);

        return await actor.AddCourse(command);
    }
    
    [HttpDelete("{venueId}/courses/{courseId}")]
    public async Task<CommandResult> DeleteCourseAsync([FromRoute] Guid venueId, [FromRoute]Guid courseId)
    {
        var actor = _clusterClient.GetGrain<IVenueActor>(venueId);

        return await actor.DeleteCourse(new DeleteCourseFromVenueCommand(venueId, courseId));
    }
    
    [HttpPost("{venueId}/courses/{courseId}/address")]
    public async Task<CommandResult> SetCourseAddressAsync([FromRoute] Guid venueId, [FromBody]SetCourseAddressCommand command)
    {
        var actor = _clusterClient.GetGrain<IVenueActor>(venueId);

        return await actor.SetCourseAddress(command);
    }
    
    [HttpPost("{venueId}/courses/{courseId}/metadata")]
    public async Task<CommandResult> SetCourseMetaDataAsync([FromRoute] Guid venueId, [FromBody]SetCourseMetaData command)
    {
        var actor = _clusterClient.GetGrain<IVenueActor>(venueId);

        return await actor.SetCourseMetaData(command);
    }
    
    [HttpPost("{venueId}/courses/{courseId}/routing")]
    public async Task<CommandResult> SetCourseRouteDataAsync([FromRoute] Guid venueId, [FromBody]SetCourseRouteDataCommand command)
    {
        var actor = _clusterClient.GetGrain<IVenueActor>(venueId);

        return await actor.SetCourseRouteData(command);
    }
    #endregion
}