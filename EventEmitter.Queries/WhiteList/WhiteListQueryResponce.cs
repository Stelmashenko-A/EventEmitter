using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EventEmitter.Queries.WhiteList
{
    [DataContract]
    public class WhiteListQueryResponce
    {
        [DataMember(Name = "records")]
        public IEnumerable<WhiteListRecord> Records { get; set; }

        [DataMember(Name = "name")]
        public string EventName { get; set; }

        [DataMember(Name = "start")]
        public DateTime EventStart { get; set; }
    }
}