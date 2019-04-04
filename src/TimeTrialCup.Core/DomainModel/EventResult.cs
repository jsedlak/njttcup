using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TimeTrialCup.DomainModel
{
    public sealed class EventResult
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("course")]
        public string Course { get; set; }

        [JsonProperty("subCourse")]
        public string SubCourse { get; set; }

        [JsonProperty("dayOfEvent")]
        public DateTime DayOfEvent { get; set; }

        [JsonProperty("usacPermit")]
        public string UsacPermit { get; set; }

        [JsonProperty("categories")]
        public IEnumerable<CategoryResult> Categories { get; set; }
    }
}
