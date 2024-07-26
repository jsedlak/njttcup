﻿using MongoDB.Driver;

namespace CupKeeper.Data;

public abstract class MongoViewRepository<TView> : IViewRepository<TView> where TView : IView
{
    private readonly IMongoClient _mongoClient;
    private readonly string _databaseName;
    private readonly string _collectionName;

    protected MongoViewRepository(IMongoClient mongoClient, string databaseName, string collectionName)
    {
        _mongoClient = mongoClient;
        _databaseName = databaseName;
        _collectionName = collectionName;
    }

    protected IMongoCollection<TView> GetCollection()
    {
        var db = _mongoClient.GetDatabase(_databaseName);
        return db.GetCollection<TView>(_collectionName);
    }

    public Task<IQueryable<TView>> QueryAsync()
    {
        var col = GetCollection();
        return Task.FromResult((IQueryable<TView>)col.AsQueryable());
    }

    public async Task<TView?> GetAsync(Guid id)
    {
        var col = GetCollection();
        return (await col.FindAsync(m => m.Id == id)).FirstOrDefault();
    }

    public async Task UpsertAsync(TView viewModel)
    {
        var col = GetCollection();
        await col.ReplaceOneAsync(
            m => m.Id == viewModel.Id, 
            viewModel, 
            new ReplaceOptions() { IsUpsert = true }
        );
    }

    public async Task DeleteAsync(Guid id)
    {
        var col = GetCollection();
        await col.DeleteOneAsync(m => m.Id == id);
    }
}