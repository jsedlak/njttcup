using System.Net.Http.Json;
using CupKeeper.Cqrs;
using CupKeeper.Domains.Locations.Commands;
using CupKeeper.Domains.Locations.ViewModel;

namespace CupKeeper.AdminApp.Services;

public sealed class VenueService
{
    private readonly HttpClient _graphQlClient;
    private readonly HttpClient _apiClient;

    public VenueService(IHttpClientFactory httpClientFactory)
    {
        _apiClient = httpClientFactory.CreateClient(ServiceConstants.ApiHttpClientName);
        _graphQlClient = httpClientFactory.CreateClient(ServiceConstants.GraphQlHttpClientName);
    }

    public async Task<CommandResult> Create(CreateVenueCommand command)
    {
        var response = await _apiClient.PostAsJsonAsync("api/venues", command);
        return (await response.Content.ReadFromJsonAsync<CommandResult>()) ?? CommandResult.Failure("Server error");
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

internal sealed class GraphQueryWrapper<TEntity> 
    where TEntity : new() 
{
    public TEntity Data { get; set; } = new();
}