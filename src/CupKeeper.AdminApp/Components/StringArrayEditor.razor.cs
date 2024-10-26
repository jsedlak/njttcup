using Microsoft.AspNetCore.Components;

namespace CupKeeper.AdminApp.Components;

public partial class StringArrayEditor : ComponentBase
{
    private string _currentValue = "";

    private async Task Remove(string value)
    {
        Items = Items.Except(new[] { value });
        await ItemsChanged.InvokeAsync(Items);
        StateHasChanged();
    }

    private async Task Add()
    {
        if (string.IsNullOrWhiteSpace(_currentValue) || Items.Contains(_currentValue))
        {
            return;
        }
        
        Items = Items.Union(new[] { _currentValue });
        await ItemsChanged.InvokeAsync(Items);
        _currentValue = "";
        StateHasChanged();
    }
    
    [Parameter]
    public IEnumerable<string> Items { get; set; }
    
    [Parameter]
    public EventCallback<IEnumerable<string>> ItemsChanged { get; set; }
}