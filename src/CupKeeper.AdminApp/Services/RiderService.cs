using System.Net.Http.Json;
using CupKeeper.AdminApi.ApiModel;
using CupKeeper.Domains.Championships.Model;

namespace CupKeeper.AdminApp.Services;

public class RiderService : ApiServiceBase
{
    private readonly HttpClient _graphQlClient;
    private readonly HttpClient _apiClient;
    
    public RiderService(IHttpClientFactory httpClientFactory) 
        : base(httpClientFactory)
    {
        _graphQlClient = httpClientFactory.CreateClient(ServiceConstants.GraphQlHttpClientName);
        _apiClient = httpClientFactory.CreateClient(ServiceConstants.ApiHttpClientName);
    }

    public async Task SetRiderName(Guid riderId, string name)
    {
        await _apiClient.PostAsJsonAsync($"/api/riders/{riderId}/name", new SetRiderNameRequest { Name = name });
    }
    
    public async Task<IEnumerable<Rider>> GetRidersAsync()
    {
        var query = @"
        query {
          riders {
            id
            name
            teamName
            usacLicenseNumber
          }
        }
        ";
        
        var response = await _graphQlClient.PostAsJsonAsync(ServiceConstants.GraphQlPath, new { query });
        
        var result = await response.Content.ReadFromJsonAsync<GraphQueryWrapper<RiderQueryWrapper>>() ?? new();
        return result.Data.Riders;
    }
    
    private class RiderQueryWrapper
    {
        public IEnumerable<Rider> Riders { get; set; } = [];
    }
}