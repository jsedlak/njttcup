using CupKeeper.Domains.Championships.ServiceModel;
using CupKeeper.Domains.Championships.Services;
using CupKeeper.Domains.Locations.ServiceModel;
using CupKeeper.Domains.Locations.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using Orleans.Configuration;
using Orleans.SyncWork.ExtensionMethods;
using Petl.EventSourcing;
using Petl.EventSourcing.Providers;

/*
 * NOTE: References the Infrastructure.[DOMAIN].Orleans projects to ensure grains are included
 */
await Host.CreateDefaultBuilder(args)
    .UseOrleans(silo =>
    {
        silo
            .Configure<ClusterOptions>(options =>
            {
                options.ClusterId = "njttcup-cluster";
                options.ServiceId = "NJTTCupService";
            })
            .ConfigureServices((services) =>
            {
                // our custom services
                services.AddSingleton<IRiderLocatorService, InMemoryRiderLocatorService>();
                services.AddScoped<IEventViewRepository, MongoEventViewRepository>();
                services.AddScoped<IVenueViewRepository, MongoVenueViewRepository>();
                services.AddScoped<IResultsLoader, UsaCyclingWebResultsLoader>();
                
                // Adds support for the EventSourcedGrain, using mongodb
                services.AddOrleansSerializers();
                services.AddMongoEventSourcing("njttcup");
            })
            .UseMongoDBClient(sp =>
            {
                var host = Environment.GetEnvironmentVariable("MONGO_HOST");
                var username = Environment.GetEnvironmentVariable("MONGO_USERNAME");
                var password = Environment.GetEnvironmentVariable("MONGO_PASSWORD");
                
                var connectionString = $"mongodb://{username}:{password}@{host}";
                
                return MongoClientSettings.FromConnectionString(connectionString);
            })
            .UseInMemoryReminderService()
            .ConfigureSyncWorkAbstraction(Math.Max(Environment.ProcessorCount - 2, 1))
            .AddReminders()
            .AddMemoryStreams("StreamProvider")
            .AddMongoDBGrainStorage("PubSubStore", options => options.DatabaseName = "njttcup-pubsub")
            .AddMongoDBGrainStorageAsDefault(options => options.DatabaseName = "njttcup-grains")
            .UseMongoDBClustering(options =>
            {
                options.DatabaseName = "njttcup-cluster";
            });
    })
    .RunConsoleAsync();