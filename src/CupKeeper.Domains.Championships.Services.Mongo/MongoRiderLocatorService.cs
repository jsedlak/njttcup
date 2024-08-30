using CupKeeper.Data;
using CupKeeper.Domains.Championships.Model;
using CupKeeper.Domains.Championships.ServiceModel;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CupKeeper.Domains.Championships.Services;

public sealed class MongoRiderLocatorService : IRiderLocatorService
{
    private readonly IMongoClient _mongoClient;
    private readonly string _databaseName;
    private readonly string _collectionName = "riders";

    public MongoRiderLocatorService(IMongoClient mongoClient, IOptions<MongoRiderLocatorServiceOptions> options)
    {
        _mongoClient = mongoClient;
        _databaseName = options.Value.DatabaseName;
    }

    private IMongoCollection<Rider> GetCollection()
    {
        return _mongoClient
            .GetDatabase(_databaseName)
            .GetCollection<Rider>(_collectionName);
    }

    public async Task<Rider> GetAsync(string name, string? teamName, string? license)
    {
        var col = GetCollection();

        if (!string.IsNullOrEmpty(license))
        {
            var rider = (await col.FindAsync(x => x.UsacLicenseNumber == license)).FirstOrDefault();

            if (rider is not null)
            {
                return rider;
            }
        }
        
        var namedRider = (await col.FindAsync(m => m.Name.ToLower() == name.ToLower().Trim())).FirstOrDefault();

        if (namedRider is not null)
        {
            return namedRider;
        }

        namedRider = new()
        {
            Id = Guid.NewGuid(),
            Name = name.Trim(),
            TeamName = teamName?.Trim(),
            UsacLicenseNumber = license?.Trim(),
        };
        
        await col.InsertOneAsync(namedRider);
        
        return namedRider;
    }

    public async Task<Rider> GetAsync(Guid riderId)
    {
        var col = GetCollection();
        var result = await col.FindAsync(x => x.Id == riderId);
        return await result.FirstAsync();
    }
}