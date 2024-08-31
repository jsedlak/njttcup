using CupKeeper.Domains.Championships.Model;
using CupKeeper.Domains.Championships.ServiceModel;
using HotChocolate.Data;

namespace CupKeeper.AdminApi.Queries;

[ExtendObjectType("Query")]
public class RiderQueries
{
    [UseFiltering]
    public Task<IEnumerable<Rider>> GetRiders([Service]IRiderRepository riderRepository) =>
        riderRepository.GetRidersAsync();
}