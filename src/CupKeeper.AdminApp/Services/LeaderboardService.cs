using System.Net.Http.Json;
using CupKeeper.Cqrs;
using CupKeeper.Domains.Championships.Commands;
using CupKeeper.Domains.Championships.ViewModel;

namespace CupKeeper.AdminApp.Services;

public sealed class LeaderboardService : ApiServiceBase
{
    private readonly HttpClient _graphQlClient;

    public LeaderboardService(IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
        _graphQlClient = httpClientFactory.CreateClient(ServiceConstants.GraphQlHttpClientName);
    }

    public async Task<CommandResult> Recalculate(Guid leaderboardId, int year)
    {
        return await ExecuteAsync($"api/leaderboards/{leaderboardId}/recalculate",
            new RecalculateLeaderboardCommand(leaderboardId) { Year = year });
    }

    public async Task<IEnumerable<LeaderboardViewModel>> GetLeaderboards()
    {
        var query = @"
        query {
            leaderboards {
                id
                year
                events
                categories {
                    id
                    name
                    order
                    riders {
                        id
                        riderId
                        name
                        team
                        rawTotal
                        total
                        points
                    }
                }
                isDeleted
                isPublished
            }
        }
        ";

        var response = await _graphQlClient.PostAsJsonAsync(ServiceConstants.GraphQlPath, new { query });

        var result = await response.Content.ReadFromJsonAsync<GraphQueryWrapper<LeaderboardQueryWrapper>>() ?? new();
        return result.Data.Leaderboards;
    }

    private class LeaderboardQueryWrapper
    {
        public IEnumerable<LeaderboardViewModel> Leaderboards { get; set; } = [];
    }
}