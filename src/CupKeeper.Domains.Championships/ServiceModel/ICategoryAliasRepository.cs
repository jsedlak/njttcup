using CupKeeper.Domains.Championships.Model;

namespace CupKeeper.Domains.Championships.ServiceModel;

public interface ICategoryAliasRepository
{
    Task<IEnumerable<CategoryAlias>> GetAll();
    
    Task Upsert(CategoryAlias categoryAlias);

    Task Delete(Guid id);
}