using CupKeeper.Domains.Championships.Actors;
using CupKeeper.Domains.Championships.Commands;
using CupKeeper.Domains.Championships.ServiceModel;
using Microsoft.Extensions.DependencyInjection;
using Orleans.TestingHost;
using Orleans.TestingHost.Utils;

namespace CupKeeper.Tests;

public class OrleansTests
{
    [Test]
    public async Task CanCreateEvent()
    {
        var builder = new TestClusterBuilder();
        var cluster = builder
            .AddSiloBuilderConfigurator<TestSiloConfigurator>()
            .AddClientBuilderConfigurator<TestClientConfigurator>()
            .Build();

        await cluster.DeployAsync();
        
        var eventId = Guid.NewGuid();
        var eventName = "Watts Up Time Trial";
        var eventGrain = cluster.GrainFactory.GetGrain<IEventActor>(eventId);

        await eventGrain.Create(new CreateScheduledEventCommand()
        {
            Name = eventName,
            VenueId = Guid.NewGuid(),
            CourseId = Guid.NewGuid(),
            ScheduledDate = DateTimeOffset.UtcNow
        });
        
        var scope = cluster.ServiceProvider.CreateScope();
        var repo = scope.ServiceProvider.GetRequiredService<IEventViewRepository>();

        await TestingUtils.WaitUntilAsync(async (lastTry) =>
        {
            var foundEvent = await repo.GetAsync(eventId);
            return foundEvent is not null;
        }, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(1));
            
        var foundEvent = await repo.GetAsync(eventId);

        Assert.IsNotNull(foundEvent);
        Assert.That(foundEvent.Name, Is.EqualTo(eventName));
        
        Assert.Pass();
        
        await cluster.StopAllSilosAsync();
        await cluster.DisposeAsync();
    }
}