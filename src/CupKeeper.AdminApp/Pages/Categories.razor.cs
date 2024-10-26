using CupKeeper.AdminApp.Services;
using CupKeeper.Domains.Championships.Model;
using Microsoft.AspNetCore.Components;
using Tazor.Components.Layout;

namespace CupKeeper.AdminApp.Pages;

public partial class Categories : ComponentBase
{
    private IEnumerable<CategoryAlias> _categoryAliases = [];
    private DialogContext<CategoryAlias> _createContext;
    private DialogContext<CategoryAlias> _editContext;

    public Categories()
    {
        _createContext = new(StateHasChanged);
        _editContext = new(StateHasChanged);
    }

    private async Task<(bool, IEnumerable<string>)> UpsertCategoryAliasCallback(CategoryAlias categoryAlias)
    {
        await CategoryAliasService.Upsert(categoryAlias);
        return (true, []);
    }
    
    private async Task RefreshAsync()
    {
        _categoryAliases = await CategoryAliasService.GetCategoryAliases();
    }
    
    protected override async Task OnInitializedAsync()
    {
        await RefreshAsync();
        await base.OnInitializedAsync();
    }

    [Inject]
    protected CategoryAliasService CategoryAliasService { get; set; }
}