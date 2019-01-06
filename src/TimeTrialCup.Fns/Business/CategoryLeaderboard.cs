using System.Collections.Generic;
using System;
using System.Linq;

namespace TimeTrialCup.Fns.Business
{
    public class CategoryLeaderboard
    {
        public RiderLeaderboard GetOrSetRider(string name, string team)
        {
            var find = Riders.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && c.Team.Equals(team, StringComparison.OrdinalIgnoreCase));

            if (find == null)
            {
                find = new RiderLeaderboard { Name = name, Team = team };
                Riders.Add(find);
            }

            return find;
        }

        public string Name { get; set; }

        public List<RiderLeaderboard> Riders { get; set; } = new List<RiderLeaderboard>();
    }

}
