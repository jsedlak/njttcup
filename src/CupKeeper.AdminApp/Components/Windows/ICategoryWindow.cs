using CupKeeper.Domains.Championships.ViewModel;

namespace CupKeeper.AdminApp.Components.Windows;

public interface ICategoryWindow
{
    Task HandleCategoryUpdated(CategoryResultViewModel category);
}