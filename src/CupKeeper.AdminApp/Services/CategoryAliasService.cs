using System.Net.Http.Json;
using CupKeeper.Domains.Championships.Model;

namespace CupKeeper.AdminApp.Services;

public sealed class CategoryAliasService : ApiServiceBase
{
    private readonly HttpClient _graphQlClient;

    public CategoryAliasService(IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
        _graphQlClient = httpClientFactory.CreateClient(ServiceConstants.GraphQlHttpClientName);
    }

    public async Task Upsert(CategoryAlias categoryAlias)
    {
        await PostAsync($"/api/category-aliases", categoryAlias);
    }

    public async Task Delete(Guid categoryAliasId)
    {
        await DeleteAsync($"/api/category-alias/{categoryAliasId}");
    }

    public async Task<IEnumerable<CategoryAlias>> GetCategoryAliases()
    {
        var query = @"
        query {
            categoryAliases
            {
                id
                name
                aliases
            }
        }";
        var response = await _graphQlClient.PostAsJsonAsync(ServiceConstants.GraphQlPath, new { query });

        var result = await response.Content.ReadFromJsonAsync<GraphQueryWrapper<CategoryAliasQueryWrapper>>() ?? new();
        return result.Data.CategoryAliases;
    }

    private class CategoryAliasQueryWrapper
    {
        public IEnumerable<CategoryAlias> CategoryAliases { get; set; } = [];
    }
}