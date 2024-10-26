using CupKeeper.AdminApp.Components;
using CupKeeper.AdminApp.Services;
using CupKeeper.Domains.Championships.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Tazor.Components.Layout;
using Tazor.Components.Theming;

namespace CupKeeper.AdminApp.Pages;

public partial class EventDetails : CupKeeperComponentBase
{
    private EventViewModel _event = new();

    private readonly DialogContext<EventViewModel> _undeleteDialogContext;
    private readonly DialogContext<EventViewModel> _deleteDialogContext;
    private readonly DialogContext<EventViewModel> _editDialogContext;
    private readonly DialogContext<EventViewModel> _unpublishDialogContext;

    private bool _isLoadingResults = false;
    private bool _isPublishing = false;

    private Timer? _loadTimer;

    public EventDetails()
    {
        _undeleteDialogContext = new(StateHasChanged);
        _deleteDialogContext = new(StateHasChanged);
        _editDialogContext = new(StateHasChanged);
        _unpublishDialogContext = new(StateHasChanged);
    }
    
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

         _event = DataContext.Events.FirstOrDefault(m => m.Id == EventId) ?? new();
        
        DataContext.PropertyChanged += (_, _) =>
        {
            _event = DataContext.Events.First(m => m.Id == EventId);
        };
    }

    private async Task<(bool, IEnumerable<string>)> UndeleteEventCallback(EventViewModel? confirmedModel)
    {
        var result = await EventService.Undelete(EventId);
        return (result.IsSuccess, result.Messages);
    }

    private async Task<(bool, IEnumerable<string>)> DeleteEventCallback(EventViewModel? confirmedModel)
    {
        var result = await EventService.Delete(EventId);
        return (result.IsSuccess, result.Messages);
    }

    private async Task<(bool, IEnumerable<string>)> UnpublishEventCallback(EventViewModel? confirmedModel)
    {
        var result = await EventService.Unpublish(EventId);
        return (result.IsSuccess, result.Messages);
    }

    private async Task<(bool, IEnumerable<string>)> SaveEventCallback(EventViewModel? confirmedModel)
    {
        if (confirmedModel is null)
        {
            return (false, ["System error."]);
        }
        
        var result = await EventService.SetScheduledDate(EventId, confirmedModel.ScheduledDate, confirmedModel.ActualDate);
        return (result.IsSuccess, result.Messages);
    }

    private async Task HandlePublishClicked()
    {
        _isPublishing = true;
        StateHasChanged();

        var response = await EventService.Publish(EventId);

        _isPublishing = false;
        _event = (await EventService.GetEvents()).First(m => m.Id == EventId);
        StateHasChanged();
    }

    private async Task LoadResultsFromUsac()
    {
        _isLoadingResults = true;

        var response = await EventService.StartLoad(EventId);

        if (response)
        {
            _loadTimer = new Timer(CheckResultsAsync, new { }, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(1));

            StateHasChanged();
        }
    }

    private async void CheckResultsAsync(object? state)
    {
        var isFinished = await EventService.CheckLoadStatus(EventId);

        if (!isFinished)
        {
            return;
        }

        _event = DataContext.Events.First(m => m.Id == EventId);
        _isLoadingResults = false;

        if (_loadTimer is not null)
        {
            await _loadTimer.DisposeAsync();
            _loadTimer = null;
        }

        StateHasChanged();
    }

    private async Task OnEditContextScheduledDateChanged(FocusEventArgs args)
    {
        if (_editDialogContext.TentativeModel.ScheduledDate == _event.ScheduledDate)
        {
            // nothing to submit
            return;
        }

        // submit to the server!
        var response = await EventService.SetScheduledDate(
            _event.Id,
            _editDialogContext.TentativeModel.ScheduledDate,
            _editDialogContext.TentativeModel.ScheduledDate
        );

        // we probably want to reload this from the server, or provide a loopback
        if (response.IsSuccess)
        {
            _event.ScheduledDate = _editDialogContext.TentativeModel.ScheduledDate;
            _event.ActualDate = _editDialogContext.TentativeModel.ScheduledDate;
            StateHasChanged();
        }
    }

    private async Task OnEditContextCourseChanged(Guid courseId)
    {
        if (courseId == _editDialogContext.TentativeModel.CourseId)
        {
            return;
        }

        _editDialogContext.TentativeModel.CourseId = courseId;

        var response = await EventService.SetCourse(
            _event.Id,
            _editDialogContext.TentativeModel.VenueId,
            _editDialogContext.TentativeModel.CourseId
        );
    }

    [Inject] protected EventService EventService { get; set; } = null!;

    [Parameter] public Guid EventId { get; set; }

    [CascadingParameter(Name = "Theme")] public ITheme Theme { get; set; } = null!;
}