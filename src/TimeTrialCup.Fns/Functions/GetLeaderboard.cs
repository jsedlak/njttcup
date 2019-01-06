using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Linq;
using TimeTrialCup.Fns.Business;
using TimeTrialCup.Fns.Extensions;

namespace TimeTrialCup.Fns.Functions
{
    public static class GetLeaderboard
    {
        [FunctionName("get_leaderboard")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "years/{year}/leaderboard")] HttpRequest req,
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
            foreach(var eventResult in eventResults)
            {
                foreach (var categoryResult in eventResult.Categories)
                {
                    var categoryLeaderboard = leaderboard.GetOrSetCategory(categoryResult.Name);

                    foreach(var riderResult in categoryResult.Results)
                    {
                        var riderLeaderboard = categoryLeaderboard.GetOrSetRider(riderResult.Name, riderResult.Team);

                        // add zeros to bring this rider up to the current event count
                        // e.g. if it's the 5th event and the rider has 2 scores, 5-1-2=2 zeros will be added (#-#-0-0-CURRENT)
                        if(riderLeaderboard.Points.Count != eventCount - 1)
                        {
                            riderLeaderboard.Points.AddRange(Enumerable.Range(0, eventCount - 1 - riderLeaderboard.Points.Count).Select(x => 0));
                        }

                        riderLeaderboard.Points.Add(riderResult.Points);

                        // build the total by subtracting the two lowest scores
                        var (lowest, secondLowest) = riderLeaderboard.Points.Min2();
                        riderLeaderboard.Total = riderLeaderboard.Points.Sum() - lowest - secondLowest;
                    }
                }

                eventCount++;
            }

            return new OkObjectResult(leaderboard);
        }
    }

}
