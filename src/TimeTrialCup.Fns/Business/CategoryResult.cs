using System.Collections.Generic;

namespace TimeTrialCup.Fns.Business
{
    public sealed class CategoryResult
    {
        public string Name { get; set; }

        public IEnumerable<RiderResult> Results { get; set; }
    }
}
