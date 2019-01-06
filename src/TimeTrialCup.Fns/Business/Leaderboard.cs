using System.Collections.Generic;
using System;
using System.Linq;

namespace TimeTrialCup.Fns.Business
{
    public class Leaderboard
    {
        public CategoryLeaderboard GetOrSetCategory(string name)
        {
            var find = Categories.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if(find == null)
            {
                find = new CategoryLeaderboard { Name = name };
                Categories.Add(find);
            }

            return find;
        }

        public List<CategoryLeaderboard> Categories { get; set; } = new List<CategoryLeaderboard>();
    }

}
