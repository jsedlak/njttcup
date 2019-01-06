using System;
using System.Collections.Generic;

namespace TimeTrialCup.Fns.Business
{
    public sealed class EventResult
    {
        public string Name { get; set; }

        public string Source { get; set; }

        public string Course { get; set; }

        public string SubCourse { get; set; }

        public DateTime DayOfEvent { get; set; }

        public IEnumerable<CategoryResult> Categories { get; set; }
    }
}
