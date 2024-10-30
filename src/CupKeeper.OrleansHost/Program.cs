using Azure.Messaging.WebPubSub;
using CupKeeper.Domains.Championships.ServiceModel;
using CupKeeper.Domains.Championships.Services;
using CupKeeper.Domains.Locations.ServiceModel;
using CupKeeper.Domains.Locations.Services;
using CupKeeper.PubSub;
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
                // add config
                services.Configure<MongoRiderRepositoryOptions>(options => 
                    options.DatabaseName = "njttcup");
                
                // infrastructure bits
                services.AddScoped<WebPubSubServiceClient>(_ => new WebPubSubServiceClient(
                    Environment.GetEnvironmentVariable("PUBSUB_CONNECTION_STRING"),
                    "njttcup"
                ));

                // our custom services
                services.AddScoped<IRiderLocatorService, MongoRiderRepository>();
                services.AddScoped<IEventViewRepository, MongoEventViewRepository>();
                services.AddScoped<IVenueViewRepository, MongoVenueViewRepository>();
                services.AddScoped<ILeaderboardViewRepository, MongoLeaderboardViewRepository>();
                services.AddScoped<IResultsLoader, UsaCyclingWebResultsLoader>();
                services.AddScoped<ILegacyResultsLoader, LegacyResultsLoader>();
                services.AddScoped<IPubClient, AzurePubClient>();
                
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
            })
            .UseDashboard(options => options.Port = 8080);
    })
    .RunConsoleAsync();