using CupKeeper.AdminApp.Components;
using CupKeeper.AdminApp.Services;
using CupKeeper.Domains.Championships.ViewModel;
using Microsoft.AspNetCore.Components;

namespace CupKeeper.AdminApp.Pages;

public partial class LeaderboardDetails : CupKeeperComponentBase
{
    private LeaderboardViewModel _leaderboard = new();
    private bool _isCalculating = false;
    
    private async Task RefreshAsync()
    {
        _leaderboard = (await LeaderboardService.GetLeaderboards())
            .FirstOrDefault(m => m.Id == LeaderboardId) ?? new();
    }

    private IEnumerable<object> GetEvents() 
    {
        return DataContext.Events
            .Where(m => _leaderboard.Events.Contains(m.Id))
            .OrderBy(m => m.ActualDate);
    }

    private async Task Recalculate()
    {
        _isCalculating = true;
        StateHasChanged();
        
        await LeaderboardService.Recalculate(LeaderboardId, _leaderboard.Year);
        
        _isCalculating = false;
        StateHasChanged();
        
        await RefreshAsync();
    }

    protected override async Task OnInitializedAsync()
    {
        await RefreshAsync();
        await base.OnInitializedAsync();
    }
    
    [Inject]
    protected LeaderboardService LeaderboardService { get; set; }
    
    [Parameter] public Guid LeaderboardId { get; set; }
}