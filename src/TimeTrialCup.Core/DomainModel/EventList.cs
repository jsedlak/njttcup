using Newtonsoft.Json;
using System.Collections.Generic;

namespace TimeTrialCup.DomainModel
{
    public sealed class EventList
    {
        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("events")]
        public IEnumerable<EventListItem> Events { get; set; }
    }
}
