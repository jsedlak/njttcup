using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using Petl.EventSourcing;
using Petl.EventSourcing.Providers;

/*
 * NOTE: References the Infrastructure.[DOMAIN].Orleans projects to ensure grains are included
 */
await Host.CreateDefaultBuilder(args)
    .UseOrleans(silo =>
    {
        silo
            .ConfigureServices((services) =>
            {
                services.AddScoped<IMongoClient, MongoClient>(sp => new MongoClient(
                    MongoClientSettings.FromConnectionString("mongodb://localadmin:thisisapassword@localhost:27017/")
                ));
                
                // Adds support for the EventSourcedGrain, using mongodb
                services.AddOrleansEventSerializer();
                services.AddMongoEventSourcing("njttcup");
            })
            .AddMemoryStreams("StreamProvider")
            .AddMemoryGrainStorage("PubSubStore")
            .UseLocalhostClustering();
    })
    .RunConsoleAsync();