using System.Runtime.Serialization;

namespace DataMiner.Services.Models
{
    [DataContract]
    public class Pagination
    {
        [DataMember(Name = "page_summary")]
        public string PageSummary { get; set; }

        [DataMember(Name = "object_count")]
        public int ObjectCount { get; set; }

        [DataMember(Name = "page_count")]
        public int PageCount { get; set; }

        [DataMember(Name = "page_number")]
        public int PageNumber { get; set; }

        [DataMember(Name = "page_size")]
        public int PageSize { get; set; }
    }
}