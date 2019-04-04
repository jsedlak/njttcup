using Newtonsoft.Json;
using System.Collections.Generic;

namespace TimeTrialCup.DomainModel
{
    public sealed class CategoryResult
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("results")]
        public IEnumerable<RiderResult> Results { get; set; }
    }
}
