using CupKeeper.Domains.Championships.ServiceModel;
using CupKeeper.Domains.Championships.Services;
using CupKeeper.Domains.Locations.ServiceModel;
using CupKeeper.Domains.Locations.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using Orleans.Configuration;
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
                
                // Adds support for the EventSourcedGrain, using mongodb
                services.AddOrleansEventSerializer();
                services.AddMongoEventSourcing("njttcup");
            })
            .UseMongoDBClient(sp =>
            {
                var config = sp.GetRequiredService<IConfiguration>();
                return MongoClientSettings.FromConnectionString(config.GetConnectionString("Mongo"));
            })
            .UseInMemoryReminderService()
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