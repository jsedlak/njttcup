using System.Net.Http.Json;
using CupKeeper.Cqrs;
using CupKeeper.Domains.Championships.Commands;
using CupKeeper.Domains.Championships.ViewModel;

namespace CupKeeper.AdminApp.Services;

public sealed class EventService : ApiServiceBase
{
    private readonly HttpClient _graphQlClient;
    

    public EventService(IHttpClientFactory httpClientFactory) 
        : base(httpClientFactory)
    {
        _graphQlClient = httpClientFactory.CreateClient(ServiceConstants.GraphQlHttpClientName);
    }

    public Task<CommandResult> Create(CreateScheduledEventCommand command)
    {
        return ExecuteAsync("api/events", command);
    }

    public async Task<IEnumerable<EventViewModel>> GetEvents()
    {
        var query = @"
        query {
          events {
            actualDate
            championshipYear
            courseId
            courseName
            id
            isDeleted
            name
            registrationLink
            scheduledDate
            usacPermitNumber
            usacResultsLink
            venueId
            venueName
          }
        }
        ";
        
        var response = await _graphQlClient.PostAsJsonAsync(ServiceConstants.GraphQlPath, new { query });
        
        var result = await response.Content.ReadFromJsonAsync<GraphQueryWrapper<EventQueryWrapper>>() ?? new();
        return result.Data.Events;
    }
    
    private class EventQueryWrapper
    {
        public IEnumerable<EventViewModel> Events { get; set; } = [];
    }
}