using CupKeeper.Domains.Championships.ServiceModel;
using CupKeeper.Domains.Championships.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orleans.TestingHost;
using Petl.EventSourcing;

namespace CupKeeper.Tests;

public class TestClientConfigurator : IClientBuilderConfigurator
{
    public void Configure(IConfiguration configuration, IClientBuilder clientBuilder)
    {
        clientBuilder.Services
            .AddScoped<IEventViewRepository, InMemoryEventViewRepository>(sp => TestInitializer.ViewRepositoryInstance)
            .AddScoped<IRiderLocatorService, InMemoryRiderLocatorService>()
            .AddScoped<IResultsLoader, UsaCyclingWebResultsLoader>();
        clientBuilder.AddMemoryStreams("StreamProvider");
        clientBuilder.Services.AddOrleansEventSerializer();
        clientBuilder.Services.AddMemoryEventSourcing();
    }
}