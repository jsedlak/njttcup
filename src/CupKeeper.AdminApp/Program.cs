using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CupKeeper.AdminApp;
using CupKeeper.AdminApp.Services;
using CupKeeper.Domains.Championships.ViewModel;
using Tazor.Components;
using Tazor.Wasm;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient(
    ServiceConstants.GraphQlHttpClientName,
    client => client.BaseAddress = new Uri("http://localhost:8001/")
);
builder.Services.AddHttpClient(
    ServiceConstants.ApiHttpClientName,
    client => client.BaseAddress = new Uri("http://localhost:8001/")
);

builder.Services.AddSingleton<VenueService>();
builder.Services.AddSingleton<EventService>();
builder.Services.AddSingleton<RiderService>();
builder.Services.AddSingleton<LeaderboardService>();
builder.Services.AddSingleton<CategoryAliasService>();
builder.Services.AddSingleton<PubSubServiceFactory>();
builder.Services.AddSingleton<DataContextService>();

builder.Services.AddTazor()
    .WithDragAndDrop()
    .Build();

var app = builder.Build();

await app.UseTazor();
    
await app.RunAsync();