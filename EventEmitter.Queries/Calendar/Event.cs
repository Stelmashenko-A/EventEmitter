using System;
using System.Runtime.Serialization;

namespace EventEmitter.Queries.Calendar
{
    [DataContract]
    public class Event
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "start")]
        public DateTime Start { get; set; }
        [DataMember(Name = "end")]
        public DateTime End { get; set; }
        [DataMember(Name = "desc")]
        public string Description { get; set; }
    }
}
