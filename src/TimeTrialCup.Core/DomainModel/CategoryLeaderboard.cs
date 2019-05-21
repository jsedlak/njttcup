using System.Collections.Generic;
using System;
using System.Linq;
using Newtonsoft.Json;
using System.Diagnostics;

namespace TimeTrialCup.DomainModel
{
    public class CategoryLeaderboard
    {
        public RiderLeaderboard GetOrSetRider(string name, string team, string license = null)
        {
            try
            {
                if (name == null) { name = ""; }
                if (team == null) { team = ""; }

                // find by name
                var find = Riders.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && !string.IsNullOrWhiteSpace(c.Team) && c.Team.Equals(team, StringComparison.OrdinalIgnoreCase));

                // find by license if null
                if (find == null && !string.IsNullOrWhiteSpace(license) && license != "0")
                {
                    find = Riders.FirstOrDefault(c => !string.IsNullOrWhiteSpace(c.License) && c.License.Equals(license, StringComparison.OrdinalIgnoreCase));
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
            catch(Exception ex)
            {
                // Trace.TraceError(ex.Message, ex.StackTrace);
                return null;
            }
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("riders")]
        public List<RiderLeaderboard> Riders { get; set; } = new List<RiderLeaderboard>();
    }

}
