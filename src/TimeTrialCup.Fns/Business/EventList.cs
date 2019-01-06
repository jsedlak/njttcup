using System.Collections.Generic;

namespace TimeTrialCup.Fns.Business
{
    public sealed class EventList
    {
        public int Year { get; set; }

        public IEnumerable<EventListItem> Events { get; set; }
    }
}
