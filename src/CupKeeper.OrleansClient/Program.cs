// See https://aka.ms/new-console-template for more information

using CupKeeper.Domains.Championships.Actors;
using CupKeeper.Domains.Championships.Commands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .UseOrleansClient(client =>
    {
        client.UseLocalhostClustering();
    })
    .UseConsoleLifetime()
    .Build();
    
await host.StartAsync();

var client = host.Services.GetRequiredService<IClusterClient>();

var eventId = Guid.NewGuid();
var eventName = "Watts Up Time Trial";
var eventGrain = client.GetGrain<IEventActor>(eventId);

await eventGrain.Create(new CreateScheduledEventCommand()
{
    Name = eventName,
    VenueId = Guid.NewGuid(),
    CourseId = Guid.NewGuid(),
    ScheduledDate = DateTimeOffset.UtcNow
});

await host.StopAsync();