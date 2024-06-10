using System.Linq.Expressions;
using CupKeeper.Domains.Championships.Model;

namespace CupKeeper.Domains.Championships.ServiceModel;

public interface IRiderRepository
{
    Task<Rider> GetOrSetAsync(string name, string license, Func<Rider> create);

    Task<Rider> UpsertAsync(Rider rider);

    Task<IEnumerable<Rider>> QueryAsync(Expression<Func<Rider, bool>> predicate);
}