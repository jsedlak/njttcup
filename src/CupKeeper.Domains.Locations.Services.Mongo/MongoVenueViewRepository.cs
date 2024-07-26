using CupKeeper.Data;
using CupKeeper.Domains.Locations.ServiceModel;
using CupKeeper.Domains.Locations.ViewModel;
using MongoDB.Driver;

namespace CupKeeper.Domains.Locations.Services;

public class MongoVenueViewRepository : MongoViewRepository<VenueViewModel>, IVenueViewRepository
{
    public MongoVenueViewRepository(IMongoClient mongoClient)
        : base(mongoClient, "njttcup", "views_venues")
    {
    }
}