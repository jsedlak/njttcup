using CupKeeper.Data;
using CupKeeper.Domains.Championships.ServiceModel;
using CupKeeper.Domains.Championships.ViewModel;
using MongoDB.Driver;

namespace CupKeeper.Domains.Championships.Services;

public class MongoLeaderboardViewRepository : MongoViewRepository<LeaderboardViewModel>, ILeaderboardViewRepository
{
    public MongoLeaderboardViewRepository(IMongoClient mongoClient)
        : base(mongoClient, "njttcup", "views_leaderboards")
    {
    }
}