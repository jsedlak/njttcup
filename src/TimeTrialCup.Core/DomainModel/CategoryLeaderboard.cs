using System.Collections.Generic;
using System;
using System.Linq;
using Newtonsoft.Json;

namespace TimeTrialCup.DomainModel
{
    public class CategoryLeaderboard
    {
        public RiderLeaderboard GetOrSetRider(string name, string team, string license = null)
        {
            if(name == null) { name = ""; }
            if(team == null) { team = ""; }

            // find by name
            var find = Riders.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && c.Team.Equals(team, StringComparison.OrdinalIgnoreCase));

            // find by license if null
            if(find == null && !string.IsNullOrWhiteSpace(license) && license != "0")
            {
                find = Riders.FirstOrDefault(c => c.License.Equals(license, StringComparison.OrdinalIgnoreCase));
            }

            if (find == null)
            {
                find = new RiderLeaderboard
                {
                    Name = name,
                    Team = team,
                    License = license
                };

                Riders.Add(find);
            }

            return find;
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("riders")]
        public List<RiderLeaderboard> Riders { get; set; } = new List<RiderLeaderboard>();
    }

}
