using CupKeeper.Domains.Championships.Model;
using CupKeeper.Domains.Championships.ServiceModel;
using Microsoft.AspNetCore.Mvc;

namespace CupKeeper.AdminApi.Controllers;

[ApiController]
[Route("/api/category-aliases")]
public class CategoryAliasesController : Controller
{
    private readonly ICategoryAliasRepository _categoryAliasRepository;

    public CategoryAliasesController(ICategoryAliasRepository categoryAliasRepository)
    {
        _categoryAliasRepository = categoryAliasRepository;
    }

    [HttpPost]
    public async Task Upsert([FromBody] CategoryAlias categoryAlias)
    {
        await _categoryAliasRepository.Upsert(categoryAlias);
    }

    [HttpDelete("{categoryAliasId}")]
    public async Task Delete([FromRoute] Guid categoryAliasId)
    {
        await _categoryAliasRepository.Delete(categoryAliasId);
    }
}