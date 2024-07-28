using System.Net.Http.Json;
using CupKeeper.Cqrs;
using CupKeeper.Domains.Locations.Commands;
using CupKeeper.Domains.Locations.ViewModel;

namespace CupKeeper.AdminApp.Services;

public sealed class VenueService : ApiServiceBase
{
    private readonly HttpClient _graphQlClient;

    public VenueService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
    {
        _graphQlClient = httpClientFactory.CreateClient(ServiceConstants.GraphQlHttpClientName);
    }

    public Task<CommandResult> Create(CreateVenueCommand command)
    {
        return ExecuteAsync("api/venues", command);
    }

    public Task<CommandResult> AddCourse(AddCourseToVenueCommand command)
    {
        return ExecuteAsync($"api/venues/{command.VenueId}/courses", command);
    }
    
    public async Task<IEnumerable<VenueViewModel>> GetVenues()
    {
        var query = @"
        query {
            venues {
                id
                name
                isDeleted
                parkingAddress {
                    streetAddress
                    additionalStreetAddress
                    city
                    state
                    zipCode
                    country
                }
                courses {
                    id
                    name
                    routeLink
                    rideWithGpsId
                    description
                    mileage
                    isDeleted
                    address {
                        streetAddress
                        additionalStreetAddress
                        city
                        state
                        zipCode
                        country
                    }
                }
            }
        }
        ";
        
        var response = await _graphQlClient.PostAsJsonAsync(ServiceConstants.GraphQlPath, new { query });
        
        var result = await response.Content.ReadFromJsonAsync<GraphQueryWrapper<VenueQueryWrapper>>() ?? new();
        return result.Data.Venues;
        //return [];
    }

    private class VenueQueryWrapper
    {
        public IEnumerable<VenueViewModel> Venues { get; set; } = [];
    }
}