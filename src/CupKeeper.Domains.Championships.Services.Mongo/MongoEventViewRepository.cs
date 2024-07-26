using CupKeeper.Data;
using CupKeeper.Domains.Championships.ServiceModel;
using CupKeeper.Domains.Championships.ViewModel;
using MongoDB.Driver;

namespace CupKeeper.Domains.Championships.Services;

public class MongoEventViewRepository : MongoViewRepository<EventViewModel>, IEventViewRepository
{
    private readonly IMongoClient _mongoClient;

    public MongoEventViewRepository(IMongoClient mongoClient)
        : base(mongoClient, "njttcup", "views_events")
    {
        _mongoClient = mongoClient;
    }
}