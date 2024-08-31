using CupKeeper.Domains.Championships.Model;

namespace CupKeeper.Domains.Championships.ServiceModel;

public interface IRiderRepository
{
    Task<IEnumerable<Rider>> GetRidersAsync();
    
    Task CreateAsync(Rider rider);
    
    Task UpdateAsync(Rider rider);
    
    Task DeleteAsync(Rider rider);
    
    Task DeleteAsync(Guid riderId);
}