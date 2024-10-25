using Azure.Messaging.WebPubSub;
using CupKeeper.AdminApi.Queries;
using CupKeeper.Domains.Championships.ServiceModel;
using CupKeeper.Domains.Championships.Services;
using CupKeeper.Domains.Locations.ServiceModel;
using CupKeeper.Domains.Locations.Services;
using MongoDB.Driver;
using Orleans.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddHealthChecks();

// Infrastructure
// builder.Services.AddMongoDBClient(sp =>
// {
//     var config = sp.GetRequiredService<IConfiguration>();
//     return MongoClientSettings.FromConnectionString(config.GetConnectionString("Mongo"));
// });

// configure our services
builder.Services.Configure<MongoRiderRepositoryOptions>(options => 
    builder.Configuration.GetSection("riders").Bind(options));

// Add our custom services
builder.Services.AddScoped<IEventViewRepository, MongoEventViewRepository>();
builder.Services.AddScoped<IVenueViewRepository, MongoVenueViewRepository>();
builder.Services.AddScoped<IRiderRepository, MongoRiderRepository>();
builder.Services.AddScoped<ILeaderboardViewRepository, MongoLeaderboardViewRepository>();

// infrastructure bits
builder.Services.AddScoped<WebPubSubServiceClient>(_ => new WebPubSubServiceClient(
    Environment.GetEnvironmentVariable("PUBSUB_CONNECTION_STRING"),
    "njttcup"
));

// Add GraphQL
builder.Services
    .AddGraphQLServer()
    .AddFiltering()
    .AddQueryType(q => q.Name("Query"))
    .AddType<EventQueries>()
    .AddType<VenueQueries>()
    .AddType<RiderQueries>()
    .AddType<LeaderboardQueries>();

// Add Orleans Client
builder.UseOrleansClient(clientBuilder =>
{
    clientBuilder
        .Configure<ClusterOptions>(options =>
        {
            options.ClusterId = "njttcup-cluster";
            options.ServiceId = "NJTTCupService";
        })
        .UseMongoDBClient(sp =>
        {
            var host = Environment.GetEnvironmentVariable("MONGO_HOST");
            var username = Environment.GetEnvironmentVariable("MONGO_USERNAME");
            var password = Environment.GetEnvironmentVariable("MONGO_PASSWORD");
                
            var connectionString = $"mongodb://{username}:{password}@{host}";
            
            // var config = sp.GetRequiredService<IConfiguration>();
            return MongoClientSettings.FromConnectionString(connectionString);
        })
        .UseMongoDBClustering(options =>
        {
            options.DatabaseName = "njttcup-cluster";
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseHealthChecks("/healthz");

// app.UseHttpsRedirection();
app.UseCors(policyBuilder => policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseAuthorization();
app.MapControllers();
app.MapGraphQL();
app.Run();