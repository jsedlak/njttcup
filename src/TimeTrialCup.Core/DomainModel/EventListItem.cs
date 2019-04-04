using Newtonsoft.Json;
using System;

namespace TimeTrialCup.DomainModel
{
    public sealed class EventListItem
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("course")]
        public string Course { get; set; }

        [JsonProperty("subCourse")]
        public string SubCourse { get; set; }

        [JsonProperty("dayOfEvent")]
        public DateTime DayOfEvent { get; set; }

        [JsonProperty("sourceUri")]
        public string SourceUri { get; set; }
    }
}
