using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EventEmitter.Queries.BlackList
{
    [DataContract]
    public class BlackListQueryResponce
    {
        [DataMember(Name = "records")]
        public IEnumerable<BlackListRecord> Records { get; set; }

        [DataMember(Name = "name")]
        public string EventName { get; set; }

        [DataMember(Name = "start")]
        public DateTime EventStart { get; set; }
    }
}