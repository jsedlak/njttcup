using System;

namespace TimeTrialCup.Fns.Business
{
    public sealed class EventListItem
    {
        public string Name { get; set; }

        public string Course { get; set; }

        public string SubCourse { get; set; }

        public DateTime DayOfEvent { get; set; }

        public string SourceUri { get; set; }
    }
}
