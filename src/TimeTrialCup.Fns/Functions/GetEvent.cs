using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using TimeTrialCup.DomainModel;

namespace TimeTrialCup.Fns.Functions
{
    public static class GetEvent
    {
        [FunctionName("get_event")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "years/{year}/events/{name}")] HttpRequest req,
            int year,
            string name,
            ILogger log,
            ExecutionContext context)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(context.FunctionAppDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var repo = new AzureStorageRepository(config);
            var results = await repo.GetFile<EventResult>($"{year}/events/{name}");
            return new OkObjectResult(results);
        }
    }

}
