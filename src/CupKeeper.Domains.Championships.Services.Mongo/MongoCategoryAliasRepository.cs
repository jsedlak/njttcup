using CupKeeper.Domains.Championships.Model;
using CupKeeper.Domains.Championships.ServiceModel;
using MongoDB.Driver;

namespace CupKeeper.Domains.Championships.Services;

public class MongoCategoryAliasRepository : ICategoryAliasRepository
{
    private readonly IMongoClient _mongoClient;
    private readonly string _databaseName;
    private readonly string _collectionName;

    public MongoCategoryAliasRepository(IMongoClient mongoClient, string databaseName, string collectionName)
    {
        _mongoClient = mongoClient;
        _databaseName = databaseName;
        _collectionName = collectionName;
    }

    protected IMongoCollection<CategoryAlias> GetCollection()
    {
        var db = _mongoClient.GetDatabase(_databaseName);
        return db.GetCollection<CategoryAlias>(_collectionName);
    }

    public Task<IEnumerable<CategoryAlias>> GetAll()
    {
        return Task.FromResult((IEnumerable<CategoryAlias>)GetCollection().AsQueryable());
    }

    public async Task Upsert(CategoryAlias categoryAlias)
    {
        var col = GetCollection();
        await col.ReplaceOneAsync(
            m => m.Id == categoryAlias.Id, 
            categoryAlias, 
            new ReplaceOptions() { IsUpsert = true }
        );
    }

    public async Task Delete(Guid id)
    {
        var col = GetCollection();
        await col.DeleteOneAsync(m => m.Id == id);
    }
}