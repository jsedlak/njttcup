using System.Net;
using System.Net.Http.Json;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Io;
using CupKeeper.Domains.Championships.Model.Parsing;
using CupKeeper.Domains.Championships.ServiceModel;
using Microsoft.Extensions.Logging;

namespace CupKeeper.Domains.Championships.Services;

public sealed class UsaCyclingWebResultsLoader : IResultsLoader
{
    private readonly CookieContainer _cookieContainer;
    private readonly HttpClientHandler _handler;
    private readonly HttpClient _client;
    private readonly ILogger<UsaCyclingWebResultsLoader> _logger;

    public UsaCyclingWebResultsLoader(ILogger<UsaCyclingWebResultsLoader> logger)
    {
        _cookieContainer = new CookieContainer();

        _handler = new HttpClientHandler();
        _handler.CookieContainer = _cookieContainer;

        _client = new HttpClient(_handler);

        _logger = logger;
    }

    private async Task<string> GetPermitIdentifier(string permit)
    {
        var response = await _client.GetAsync($"https://legacy.usacycling.org/results/?permit={permit}");

        using var context = BrowsingContext.New(
            Configuration.Default
                .WithJs()
                .WithCss()
                .WithDefaultLoader(new LoaderOptions { IsResourceLoadingEnabled = true })
        );

        var masterDocument = await context.OpenAsync($"https://legacy.usacycling.org/results/?permit={permit}");
        await masterDocument.WaitUntilAvailable();

        var data = masterDocument.DocumentElement.QuerySelectorAll("#resultsmain script").First().InnerHtml.Trim()
            .Replace("loadInfoID(", "");
        return data.Substring(0, data.IndexOf(","));
    }

    private async Task<IEnumerable<UsacCategoryResult>> GetRacesForPermit(string masterId)
    {
        var categoryApiResult = await _client.GetFromJsonAsync<UsacApiResult>(
            $"https://legacy.usacycling.org/results/index.php?ajax=1&act=infoid&info_id={masterId}&label=");

        using var context = BrowsingContext.New(
            Configuration.Default
                .WithJs()
                .WithCss()
                .WithDefaultLoader(new LoaderOptions { IsResourceLoadingEnabled = true })
        );

        var categoryDocument = await context.OpenAsync(req => req.Content(categoryApiResult.message));
        await categoryDocument.WaitUntilAvailable();

        return categoryDocument.DocumentElement.QuerySelectorAll("#results_list li").Select(m => new UsacCategoryResult
            { Id = m.GetAttribute("id").Replace("race_", ""), Name = m.QuerySelector("a").GetInnerText() });
    }

    /// <summary>
    /// Retrieves an event's results from the legacy USA Cycling website by parsing all the html
    /// </summary>
    /// <param name="raceIdentifier"></param>
    /// <returns></returns>
    public async Task<ParsedEventResult> GetResults(string raceIdentifier)
    {
        var masterId = await GetPermitIdentifier(raceIdentifier);

        var eventResult = new ParsedEventResult()
        {
            Identifier = masterId
        };

        _logger.LogInformation($"Loading results for Permit {masterId}");

        var categories = await GetRacesForPermit(masterId);

        var categoryResults = new List<ParsedCategoryResult>();

        using var context = BrowsingContext.New(
            Configuration.Default
                .WithJs()
                .WithCss()
                .WithDefaultLoader(new LoaderOptions { IsResourceLoadingEnabled = true })
        );

        foreach (var cat in categories)
        {
            var categoryResult = new ParsedCategoryResult { Name = cat.Name };

            _logger.LogInformation($"Category Found: {cat.Id} => {cat.Name}");
            
            var leaderboardApiResult = await _client.GetFromJsonAsync<UsacApiResult>(
                $"https://legacy.usacycling.org/results/index.php?ajax=1&act=loadresults&race_id={cat.Id}");

            var leaderboardDocument = await context.OpenAsync(req => req.Content(leaderboardApiResult?.message));
            await leaderboardDocument.WaitUntilAvailable();

            var tableRows = leaderboardDocument.DocumentElement.QuerySelectorAll(".tablerow").Skip(1).ToArray();

            categoryResult.Results = tableRows.Select(ParseRiderResult).ToArray();

            categoryResults.Add(categoryResult);
        }

        eventResult.Categories = categoryResults.ToArray();
        return eventResult;
    }

    private ParsedRiderResult ParseRiderResult(IElement row)
    {
        var cells = row.QuerySelectorAll(".tablecell").ToArray();
        var placeText = cells[1].GetInnerText();

        var timeText = cells[6].GetInnerText();

        if (timeText.IndexOf(':') == -1)
        {
            var split = timeText.Split('.', StringSplitOptions.RemoveEmptyEntries);
            timeText = string.Join(":", split);
        }

        if (timeText.Count(m => m == ':') == 1)
        {
            timeText = "0:" + timeText;
        }

        TimeSpan.TryParse(timeText, out var time);

        return new ParsedRiderResult
        {
            Place = placeText,
            License = cells[8].GetInnerText(),
            Name = cells[4].GetInnerText().Trim().StripCategoryPlacing().ToPascalCase(),
            Team = cells[10].GetInnerText(),
            Time = time.TotalSeconds
        };
    }
}