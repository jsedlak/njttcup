using CupKeeper.AdminApp.Services;
using CupKeeper.Domains.Championships.ViewModel;
using CupKeeper.Domains.Locations.ViewModel;
using Microsoft.AspNetCore.Components;

namespace CupKeeper.AdminApp.Components;

public class CupKeeperComponentBase : ComponentBase
{
    [CascadingParameter(Name = "DataContext")] public DataContextService DataContext { get; set; }
    // [CascadingParameter(Name = "Venues")] public IEnumerable<VenueViewModel> Venues { get; set; } = [];
    //
    // [CascadingParameter(Name = "Events")] public IEnumerable<EventViewModel> Events { get; set; } = [];
    //
    // [CascadingParameter(Name = "EventCount")]public int EventCount { get; set; }
}