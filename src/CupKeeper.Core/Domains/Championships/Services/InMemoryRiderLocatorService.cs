using System.Collections.Concurrent;
using CupKeeper.Domains.Championships.Model;
using CupKeeper.Domains.Championships.ServiceModel;

namespace CupKeeper.Domains.Championships.Services;

public class InMemoryRiderLocatorService : IRiderLocatorService
{
    private static readonly ConcurrentDictionary<Guid, Rider> Riders = new();

    public Task<Rider> GetAsync(string name, string? teamName, string? license)
    {
        Rider? rider = null;

        if (!string.IsNullOrWhiteSpace(license))
        {
            rider = Riders.Values.FirstOrDefault(m =>
                m.UsacLicenseNumber != null && m.UsacLicenseNumber.Equals(license, StringComparison.OrdinalIgnoreCase));
        }

        rider ??= Riders.Values.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (rider is null)
        {
            rider = new()
            {
                Id = Guid.NewGuid(),
                Name = name,
                TeamName = teamName,
                UsacLicenseNumber = license
            };
            
            Riders.TryAdd(rider.Id, rider);
        }

        return Task.FromResult(rider);
    }
}