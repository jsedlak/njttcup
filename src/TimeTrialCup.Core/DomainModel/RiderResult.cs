using Newtonsoft.Json;
using System;

namespace TimeTrialCup.DomainModel
{
    public sealed class RiderResult
    {
        [JsonProperty("place")]
        public int Place { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("license")]
        public string License { get; set; }

        [JsonProperty("team")]
        public string Team { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }
}
