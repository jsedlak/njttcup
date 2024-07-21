using CupKeeper.Domains.Championships.ViewModel;

namespace CupKeeper.Domains.Championships.ServiceModel;

public interface IEventViewRepository
{
    Task<IQueryable<EventViewModel>> QueryAsync();
    
    Task<EventViewModel?> GetAsync(Guid id);
    
    Task UpsertAsync(EventViewModel viewModel);

    Task DeleteAsync(Guid id);
}