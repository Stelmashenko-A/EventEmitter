using System.Runtime.Serialization;

namespace DataMiner.Services.Models
{
    [DataContract]
    public class DateRange
    {
        [DataMember(Name = "start_date")]
        public string StartDate { get; set; }

        [DataMember(Name = "end_date")]
        public string EndDate { get; set; }
    }
}