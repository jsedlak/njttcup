using CupKeeper.Domains.Championships.ServiceModel;
using CupKeeper.Domains.Championships.ViewModel;
using HotChocolate.Data;

namespace CupKeeper.AdminApi.Queries;

[ExtendObjectType("Query")]
public class LeaderboardQueries
{
    [UseFiltering]
    public Task<IQueryable<LeaderboardViewModel>> GetLeaderboards([Service] ILeaderboardViewRepository leaderboardViewRepository) =>
        leaderboardViewRepository.QueryAsync();
}