using CupKeeper.Domains.Championships.ServiceModel;
using CupKeeper.Domains.Championships.ViewModel;
using HotChocolate.Data;

namespace CupKeeper.AdminApi.Queries;

[ExtendObjectType("Query")]
public class EventQueries
{
    [UseFiltering]
    public Task<IQueryable<EventViewModel>> GetEvents([Service] IEventViewRepository eventViewRepository) =>
        eventViewRepository.QueryAsync();
}