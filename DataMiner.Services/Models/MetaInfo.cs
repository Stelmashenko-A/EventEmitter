using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataMiner.Services.Models
{
    [DataContract]
    public class MetaInfo
    {
        [DataMember(Name = "sort")]
        public string Sort { get; set; }

        [DataMember(Name = "where")]
        public string Where { get; set; }

        [DataMember(Name = "what")]
        public string What { get; set; }

        [DataMember(Name = "nb_events_found")]
        public int NbEventsFound { get; set; }

        [DataMember(Name = "nb_events_per_page")]
        public int NbEventsPerPage { get; set; }

        [DataMember(Name = "current_version")]
        public int CurrentVersion { get; set; }

        [DataMember(Name = "suggestions")]
        public List<object> Suggestions { get; set; }

        [DataMember(Name = "total_pages")]
        public int TotalPages { get; set; }

        [DataMember(Name = "page")]
        public int Page { get; set; }
    }
}