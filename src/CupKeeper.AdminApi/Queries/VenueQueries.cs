using CupKeeper.Domains.Locations.ServiceModel;
using CupKeeper.Domains.Locations.ViewModel;
using HotChocolate.Data;

namespace CupKeeper.AdminApi.Queries;

[ExtendObjectType("Query")]
public class VenueQueries
{
    [UseFiltering]
    public Task<IQueryable<VenueViewModel>> GetVenues([Service] IVenueViewRepository venueViewRepository) =>
        venueViewRepository.QueryAsync();
}