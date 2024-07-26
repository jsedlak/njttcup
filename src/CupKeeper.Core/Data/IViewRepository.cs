namespace CupKeeper.Data;

public interface IViewRepository<TView> where TView : IView
{
    Task<IQueryable<TView>> QueryAsync();
    
    Task<TView?> GetAsync(Guid id);
    
    Task UpsertAsync(TView viewModel);

    Task DeleteAsync(Guid id);
}