using CupKeeper.Cqrs;
using CupKeeper.Domains.Championships.Actors;
using CupKeeper.Domains.Championships.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CupKeeper.AdminApi.Controllers;

[ApiController]
[Route("/api/events")]
public class EventsController : Controller
{
    private readonly IClusterClient _clusterClient;

    public EventsController(IClusterClient clusterClient)
    {
        _clusterClient = clusterClient;
    }
    
    #region Event Management
    [HttpPost]
    public async Task<CommandResult> CreateEventAsync([FromBody]CreateScheduledEventCommand command)
    {
        var newEventId = Guid.NewGuid();
        var actor = _clusterClient.GetGrain<IEventActor>(newEventId);

        return await actor.Create(command);
    }

    [HttpDelete("{eventId}")]
    public async Task<CommandResult> DeleteEventAsync([FromRoute]Guid eventId)
    {
        var actor = _clusterClient.GetGrain<IEventActor>(eventId);
        return await actor.Delete(new DeleteScheduledEventCommand(eventId));
    }
    
    [HttpPost("{eventId}/name")]
    public async Task<CommandResult> SetNameAsync([FromRoute]Guid eventId, [FromBody]SetEventNameCommand command)
    {
        var actor = _clusterClient.GetGrain<IEventActor>(eventId);

        return await actor.SetName(command);
    }
    
    [HttpPost("{eventId}/course")]
    public async Task<CommandResult> SetCourseAsync([FromRoute]Guid eventId, [FromBody]SetEventCourseCommand command)
    {
        var actor = _clusterClient.GetGrain<IEventActor>(eventId);

        return await actor.SetCourse(command);
    }
    
    [HttpPost("{eventId}/registration")]
    public async Task<CommandResult> SetRegistrationAsync([FromRoute]Guid eventId, [FromBody]SetEventRegistrationLinkCommand command)
    {
        var actor = _clusterClient.GetGrain<IEventActor>(eventId);

        return await actor.SetRegistration(command);
    }
    
    [HttpPost("{eventId}/dates")]
    public async Task<CommandResult> SetDatesAsync([FromRoute]Guid eventId, [FromBody]SetEventDatesCommand command)
    {
        var actor = _clusterClient.GetGrain<IEventActor>(eventId);

        return await actor.SetDates(command);
    }
    
    [HttpPost("{eventId}/usac")]
    public async Task<CommandResult> SetUsacDataAsync([FromRoute]Guid eventId, [FromBody]SetEventUsacDataCommand command)
    {
        var actor = _clusterClient.GetGrain<IEventActor>(eventId);

        return await actor.SetUsacData(command);
    }
    #endregion
    
    #region Results Management
    [HttpPost("{eventId}/results/categories")]
    public async Task<CommandResult> AddCategoryAsync([FromRoute]Guid eventId, [FromBody]AddCategoryResultCommand command)
    {
        var actor = _clusterClient.GetGrain<IEventActor>(eventId);

        return await actor.AddCategory(command);
    }
    
    [HttpDelete("{eventId}/results/categories/{categoryId}")]
    public async Task<CommandResult> RemoveCategoryAsync([FromRoute]Guid eventId, [FromBody]RemoveCategoryResultCommand command)
    {
        var actor = _clusterClient.GetGrain<IEventActor>(eventId);

        return await actor.RemoveCategory(command);
    }
    
    [HttpPost("{eventId}/results/categories/{categoryId}/name")]
    public async Task<CommandResult> SetCategoryNameAsync([FromRoute]Guid eventId, [FromBody]SetCategoryResultNameCommand command)
    {
        var actor = _clusterClient.GetGrain<IEventActor>(eventId);

        return await actor.SetCategoryName(command);
    }
    
    [HttpPost("{eventId}/results/categories/{categoryId}")]
    public async Task<CommandResult> AddRiderAsync([FromRoute]Guid eventId, [FromBody]AddRiderResultCommand command)
    {
        var actor = _clusterClient.GetGrain<IEventActor>(eventId);

        return await actor.AddRider(command);
    }
    
    [HttpDelete("{eventId}/results/categories/{categoryId}/riders/{riderId}")]
    public async Task<CommandResult> RemoveRiderAsync([FromRoute]Guid eventId, [FromBody]RemoveRiderResultCommand command)
    {
        var actor = _clusterClient.GetGrain<IEventActor>(eventId);

        return await actor.RemoveRider(command);
    }
    
    [HttpPost("{eventId}/results/riders/move")]
    public async Task<CommandResult> MoveRiderAsync([FromRoute]Guid eventId, [FromBody]MoveRiderResultCommand command)
    {
        var actor = _clusterClient.GetGrain<IEventActor>(eventId);

        return await actor.MoveRider(command);
    }
    #endregion
    
    #region Publishing
    [HttpPost("{eventId}/results/publish")]
    public async Task<CommandResult> PublishResultsAsync([FromRoute]Guid eventId, [FromBody]PublishEventResultsCommand command)
    {
        var actor = _clusterClient.GetGrain<IEventActor>(eventId);

        return await actor.PublishResults(command);
    }
    #endregion
    
    #region Ingestion
    [HttpPost("{eventId}/results/load")]
    public async Task<bool> StartLoadAsync([FromRoute]Guid eventId)
    {
        var actor = _clusterClient.GetGrain<IEventActor>(eventId);

        return await actor.StartResultsLoad();
    }
    
    [HttpGet("{eventId}/results/load/status")]
    public async Task<bool> CheckLoadAsync([FromRoute]Guid eventId)
    {
        var actor = _clusterClient.GetGrain<IEventActor>(eventId);

        return await actor.CheckResultsLoadFinished();
    }
    #endregion
}