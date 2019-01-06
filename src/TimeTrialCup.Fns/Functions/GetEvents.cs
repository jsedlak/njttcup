using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace TimeTrialCup.Fns.Functions
{
    public static class GetEvents
    {
        [FunctionName("get_events")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "years/{year}/events")] HttpRequest req,
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
            var results = await repo.GetEventsAsync(year);
            return new OkObjectResult(results);
        }
    }

}
