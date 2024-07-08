using CupKeeper.Domains.Championships.ServiceModel;
using CupKeeper.Domains.Championships.ViewModel;
using MongoDB.Driver;

namespace CupKeeper.Domains.Championships.Services;

public class MongoEventViewRepository : IEventViewRepository
{
    private readonly IMongoClient _mongoClient;

    public MongoEventViewRepository(IMongoClient mongoClient)
    {
        _mongoClient = mongoClient;
    }

    public async Task<EventViewModel?> GetAsync(Guid id)
    {
        var db = _mongoClient.GetDatabase("njttcup");
        var col = db.GetCollection<EventViewModel>("views_events");
        return (await col.FindAsync(m => m.Id == id)).FirstOrDefault();
    }

    public async Task UpsertAsync(EventViewModel viewModel)
    {
        var db = _mongoClient.GetDatabase("njttcup");
        var col = db.GetCollection<EventViewModel>("views_events");
        await col.ReplaceOneAsync(
            m => m.Id == viewModel.Id, 
            viewModel, 
            new ReplaceOptions() { IsUpsert = true }
        );
    }

    public async Task DeleteAsync(Guid id)
    {
        var db = _mongoClient.GetDatabase("njttcup");
        var col = db.GetCollection<EventViewModel>("views_events");
        await col.DeleteOneAsync(m => m.Id == id);
    }
}