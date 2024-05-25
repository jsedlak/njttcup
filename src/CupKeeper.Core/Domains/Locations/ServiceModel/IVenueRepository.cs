using CupKeeper.Domains.Locations.Model;
using System.Linq.Expressions;

namespace CupKeeper.Domains.Locations.ServiceModel;

public interface IVenueRepository
{
    Task<Venue> GetById(Guid id);

    Task<IQueryable<Venue>> Query(Expression<Func<Venue, bool>> predicate);

    Task Upsert(Venue venue);

    Task Delete(Guid id);
}
