using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Linq;
using System.Collections.Generic;
using TimeTrialCup.Fns.Business;

namespace TimeTrialCup.Fns
{
    /// <summary>
    /// Manages FILES (BLOBS) in an Azure Storage Container
    /// </summary>
    public sealed class AzureStorageRepository
    {
        public static string ResultsContainerName { get; set; } = "results";

        private readonly CloudBlobClient _client;

        public AzureStorageRepository(IConfiguration configuration) 
            : this(configuration["AzureStorageConnectionString"]) { }

        public AzureStorageRepository(string connectionString)
        {
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            _client = storageAccount.CreateCloudBlobClient();           
        }

        /// <summary>
        /// Gets a list of available years in the repository
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<int>> GetYearsAsync()
        {
            var container = _client.GetContainerReference(ResultsContainerName);
            var results = (await container.ListBlobsSegmentedAsync(null)).Results;
            var directories = results
                .Where(blob => 
                    !blob.Uri.IsFile && 
                    int.TryParse(blob.Uri.Segments[blob.Uri.Segments.Length - 1].TrimEnd('/'), out int myInt)
                );

            return directories.Select(dir => int.Parse(dir.Uri.Segments[dir.Uri.Segments.Length - 1].TrimEnd('/')));
        }

        /// <summary>
        /// Gets a full collection of event result data for a given year
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>A list of event result objects</returns>
        public async Task<IEnumerable<EventResult>> GetEventsAsync(int year)
        {
            var container = _client.GetContainerReference(ResultsContainerName);
            var directory = container.GetDirectoryReference($"{year}/events");

            // grab a list of all the files
            var allContents = (await directory.ListBlobsSegmentedAsync(null)).Results;
            var eventBlockBlobs = allContents.Where(b => b is CloudBlockBlob).Select(b => b as CloudBlockBlob);

            var list = new List<EventResult>();
            foreach(var eventBlockBlob in eventBlockBlobs)
            {                
                // download the contents of the file
                var data = await eventBlockBlob.DownloadTextAsync();

                // parse the data
                var parsedResult = JsonConvert.DeserializeObject<EventResult>(data);
                parsedResult.Source = eventBlockBlob.Uri.LocalPath;

                list.Add(parsedResult);
            }

            return list;
        }

        public async Task<TModel> GetFile<TModel>(string localPath)
        {
            var container = _client.GetContainerReference(ResultsContainerName);
            var blobReference = container.GetBlockBlobReference(localPath);

            var contents = await blobReference.DownloadTextAsync();

            return JsonConvert.DeserializeObject<TModel>(contents);
        }
    }

}
