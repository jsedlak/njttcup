using CupKeeper.Domains.Championships.ServiceModel;
using CupKeeper.Domains.Championships.Services;
using Microsoft.Extensions.DependencyInjection;
using Orleans.TestingHost;
using Petl.EventSourcing;

namespace CupKeeper.Tests;

public class TestSiloConfigurator : ISiloConfigurator
{
    public void Configure(ISiloBuilder siloBuilder)
    {
        siloBuilder.ConfigureServices(services =>
            {
                services
                    .AddScoped<IRiderLocatorService, InMemoryRiderLocatorService>()
                    .AddScoped<IEventViewRepository, InMemoryEventViewRepository>(sp => TestInitializer.ViewRepositoryInstance)
                    .AddScoped<IResultsLoader, UsaCyclingWebResultsLoader>();

                services.AddOrleansSerializers();
                services.AddMemoryEventSourcing();
            })
            .AddMemoryGrainStorageAsDefault()
            .AddMemoryGrainStorage("PubSubStore")
            .UseInMemoryReminderService()
            .AddMemoryStreams("StreamProvider");
    }
}