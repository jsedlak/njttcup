using CupKeeper.AdminApi.Queries;
using CupKeeper.Domains.Championships.ServiceModel;
using CupKeeper.Domains.Championships.Services;
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

// Add our custom services
builder.Services.AddScoped<IEventViewRepository, MongoEventViewRepository>();

// Add GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<EventQueries>()
    .AddFiltering();

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
            var config = sp.GetRequiredService<IConfiguration>();
            return MongoClientSettings.FromConnectionString(config.GetConnectionString("Mongo"));
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