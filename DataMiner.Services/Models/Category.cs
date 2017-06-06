using System.Runtime.Serialization;

namespace DataMiner.Services.Models
{
    [DataContract]
    public class Category
    {
        [DataMember(Name = "total_events_found")]
        public int TotalEventsFound { get; set; }

        [DataMember(Name = "selected")]
        public bool Selected { get; set; }

        [DataMember(Name = "value")]
        public string Value { get; set; }

        [DataMember(Name = "label")]
        public string Label { get; set; }
    }
}