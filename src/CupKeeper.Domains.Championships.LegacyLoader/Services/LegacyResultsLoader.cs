using System.Text;
using System.Text.Json;
using CupKeeper.Domains.Championships.Model.Parsing;
using CupKeeper.Domains.Championships.ServiceModel;

namespace CupKeeper.Domains.Championships.Services;

public class LegacyResultsLoader : ILegacyResultsLoader
{
    public async Task<ParsedEventResult> GetResults(string json)
    {
        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
        var jsonEvent = await JsonSerializer.DeserializeAsync<JsonEvent>(ms);

        if (jsonEvent == null)
        {
            return new();
        }

        return new ParsedEventResult()
        {
            Categories = jsonEvent.Categories.Select(cat => new ParsedCategoryResult()
            {
                Name = cat.Name,
                Results = cat.Results.Select(rider => new ParsedRiderResult()
                {
                    Name = rider.Name,
                    License = rider.License,
                    Place = rider.Place.ToString(),
                    Team = rider.Team,
                    Time = rider.Time,
                }).ToArray()
            }).ToArray()
        };
    }

    private class JsonEvent
    {
        public string Name { get; set; } = null!;

        public int Year { get; set; }

        public JsonCategoryResult[] Categories { get; set; } = [];
    }

    private class JsonCategoryResult
    {
        public string Name { get; set; } = null!;

        public JsonRiderResult[] Results { get; set; } = [];
    }

    private class JsonRiderResult
    {
        public int Place { get; set; }

        public int Points { get; set; }

        public string Name { get; set; } = null!;

        public string License { get; set; } = null!;

        public string Team { get; set; } = null!;

        public double Time { get; set; }
    }
}