using CupKeeper.Domains.Championships.ServiceModel;
using CupKeeper.Domains.Championships.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CupKeeper.Tests;

public static class TestInitializer
{
    public static InMemoryEventViewRepository ViewRepositoryInstance { get; } = new InMemoryEventViewRepository();
        
    public static void ConfigureCommonServices(IServiceCollection services)
    {
        services
            .AddLogging(builder => builder.AddDebug())
            .AddScoped<IRiderLocatorService, InMemoryRiderLocatorService>()
            .AddScoped<IEventViewRepository, InMemoryEventViewRepository>(sp => ViewRepositoryInstance)
            .AddScoped<IResultsLoader, UsaCyclingWebResultsLoader>();
    }
    
    public static IServiceProvider BuildServiceProvider(Action<IServiceCollection>? configureServices = null)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureCommonServices(serviceCollection);

        if (configureServices is not null)
        {
            configureServices(serviceCollection);
        }

        return serviceCollection.BuildServiceProvider();
    }
}