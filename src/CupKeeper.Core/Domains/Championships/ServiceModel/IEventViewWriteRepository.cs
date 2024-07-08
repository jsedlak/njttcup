using CupKeeper.Domains.Championships.ViewModel;

namespace CupKeeper.Domains.Championships.ServiceModel;

public interface IEventViewWriteRepository
{
    Task<EventViewModel?> GetAsync(Guid id);
    
    Task UpsertAsync<EventViewModel>(EventViewModel viewModel);

    Task DeleteAsync(Guid id);

}