using System.Collections.Generic;

namespace TimeTrialCup.Fns.Business
{
    public class RiderLeaderboard
    {
        public string Name { get; set; }

        public string Team { get; set; }

        public int Total { get; set; }

        public int RawTotal { get; set; }

        public List<int> Points { get; set; } = new List<int>();
    }

}
