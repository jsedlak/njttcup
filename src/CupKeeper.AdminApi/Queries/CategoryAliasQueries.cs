using CupKeeper.Domains.Championships.Model;
using CupKeeper.Domains.Championships.ServiceModel;
using HotChocolate.Data;

namespace CupKeeper.AdminApi.Queries;

[ExtendObjectType("Query")]
public class CategoryAliasQueries
{
    [UseFiltering]
    public Task<IEnumerable<CategoryAlias>> GetCategoryAliases([Service] ICategoryAliasRepository categoryAliasRepository) =>
        categoryAliasRepository.GetAll();
}