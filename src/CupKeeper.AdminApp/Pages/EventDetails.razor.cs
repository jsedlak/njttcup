using CupKeeper.AdminApp.Components;
using CupKeeper.AdminApp.Components.Windows;
using CupKeeper.Domains.Championships.ViewModel;

namespace CupKeeper.AdminApp.Pages;

public partial class EventDetails : CupKeeperComponentBase, ICategoryWindow
{
    public Task HandleCategoryUpdated(CategoryResultViewModel category)
    {
        IEnumerable<CategoryResultViewModel> newResults =
        [
            .. _event.Results.Where(m => m.Id != category.Id).ToArray(),
            category
        ];

        _event.Results = newResults.OrderBy(m => m.Order).ToArray();
        
        StateHasChanged();
        
        return Task.CompletedTask;
    }
}