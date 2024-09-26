using System.ComponentModel;
using System.Runtime.CompilerServices;
using CupKeeper.Domains.Championships.ViewModel;
using CupKeeper.Domains.Locations.ViewModel;
using CupKeeper.PubSub;
using Microsoft.AspNetCore.Components;

namespace CupKeeper.AdminApp.Services;

public class DataContextService : INotifyPropertyChanged
{
    private readonly PubSubServiceFactory _pubSubFactory;
    private readonly VenueService _venueService;
    private readonly EventService _eventService;
    private ISubClient? _subClient;
    
    public DataContextService(PubSubServiceFactory pubSubFactory, EventService eventService, VenueService venueService)
    {
        _pubSubFactory = pubSubFactory;
        _eventService = eventService;
        _venueService = venueService;
    }

    public async Task InitializeAsync()
    {
        _subClient = await _pubSubFactory.CreateClient("events");
        await _subClient.SubscribeAsync(msg =>
        {
            Console.WriteLine(msg);
            Task.Run(Rehydrate);
        });

        await Rehydrate();
    }

    private async Task Rehydrate()
    {
        if (!CanRehydrate)
        {
            return;
        }
        
        Console.WriteLine("Rehydrating...");
        
        Events = await _eventService.GetEvents();
        OnPropertyChanged(nameof(Events));

        EventCount = Events.Count();
        OnPropertyChanged(nameof(EventCount));
        
        Venues = await _venueService.GetVenues();
        OnPropertyChanged(nameof(Venues));
    }

    public bool CanRehydrate { get; set; } = true;

    public int EventCount { get; set; }

    public IEnumerable<VenueViewModel> Venues { get; set; } = [];
    

    public IEnumerable<EventViewModel> Events { get; set; } = [];
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}