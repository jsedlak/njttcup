using Newtonsoft.Json;
using System.Collections.Generic;

namespace TimeTrialCup.DomainModel
{
    public class RiderLeaderboard
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("team")]
        public string Team { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("rawTotal")]
        public int RawTotal { get; set; }

        [JsonProperty("license")]
        public string License { get; set; }

        [JsonProperty("points")]
        public List<int> Points { get; set; } = new List<int>();
    }

}
