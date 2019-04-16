using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Linq;
using TimeTrialCup.DomainModel;
using TimeTrialCup.Fns.Extensions;
using System;
using System.Collections.Generic;

namespace TimeTrialCup.Fns.Functions
{
    public static class GetLeaderboard
    {
        [FunctionName("get_leaderboard")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "years/{year}/leaderboard")] HttpRequest req,
            int year,
            ILogger log,
            ExecutionContext context)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(context.FunctionAppDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var repo = new AzureStorageRepository(config);
            var eventResults = (await repo.GetEventsAsync(year)).OrderBy(e => e.DayOfEvent);

            // start the leaderboard
            var leaderboard = new Leaderboard();

            // loop through all the events starting in date order
            int eventCount = 1;
            var ridersRefShortcut = new List<RiderLeaderboard>();

            try
            {
                foreach (var eventResult in eventResults)
                {
                    foreach (var categoryResult in eventResult.Categories)
                    {
                        var categoryLeaderboard = leaderboard.GetOrSetCategory(categoryResult.Name);

                        foreach (var riderResult in categoryResult.Results)
                        {
                            var riderLeaderboard = categoryLeaderboard.GetOrSetRider(riderResult.Name, riderResult.Team, riderResult.License);
                            ridersRefShortcut.Add(riderLeaderboard);

                            // add zeros to bring this rider up to the current event count
                            // e.g. if it's the 5th event and the rider has 2 scores, 5-1-2=2 zeros will be added (#-#-0-0-CURRENT)
                            var missingCount = eventCount - 1 - riderLeaderboard.Points.Count;
                            if (missingCount > 0)
                            {
                                riderLeaderboard.Points.AddRange(
                                    Enumerable.Range(1, missingCount).Select(x => 0)
                                );
                            }

                            riderLeaderboard.Points.Add(riderResult.Points);
                        }
                    }

                    eventCount++;
                }

                var maxCount = ridersRefShortcut.Max(rl => rl.Points.Count);
                foreach (var riderLeaderboard in ridersRefShortcut)
                {
                    var riderPointsCount = riderLeaderboard.Points.Count;
                    if (riderPointsCount < maxCount)
                    {
                        riderLeaderboard.Points.AddRange(
                            Enumerable.Range(1, maxCount - riderPointsCount).Select(r => 0)
                        );
                    }

                    // if we're less than 3 races in, there are no drops...
                    if (eventResults.Count() < 3)
                    {
                        riderLeaderboard.RawTotal = riderLeaderboard.Points.Sum();
                        riderLeaderboard.Total = riderLeaderboard.Points.Sum();
                    }
                    else
                    {
                        // build the total by subtracting the two lowest scores
                        var (lowest, secondLowest) = riderLeaderboard.Points.Min2();
                        riderLeaderboard.Total = riderLeaderboard.Points.Sum() - lowest - secondLowest;

                        riderLeaderboard.RawTotal = Math.Max(riderLeaderboard.Points.Sum(), 0);
                        riderLeaderboard.Total = Math.Max(riderLeaderboard.Total, 0);
                    }
                }

                foreach (var eventResult in eventResults)
                {
                    foreach (var categoryResult in eventResult.Categories)
                    {
                        var categoryLeaderboard = leaderboard.GetOrSetCategory(categoryResult.Name);
                        categoryLeaderboard.Riders.Sort(new RiderComparer());
                    }
                }
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new
                {
                    ex.Message,
                    ex.StackTrace
                });
            }

            return new OkObjectResult(leaderboard);
        }
    }

    public class RiderComparer : IComparer<RiderLeaderboard>
    {
        public int Compare(RiderLeaderboard x, RiderLeaderboard y)
        {
            return y.Total - x.Total;
        }
    }
}
