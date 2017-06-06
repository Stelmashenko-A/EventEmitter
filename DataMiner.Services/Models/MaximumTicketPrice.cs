using System.Runtime.Serialization;

namespace DataMiner.Services.Models
{
    [DataContract]
    public class MaximumTicketPrice
    {
        [DataMember(Name = "currency")]
        public string Currency { get; set; }

        [DataMember(Name = "value")]
        public int Value { get; set; }

        [DataMember(Name = "major_value")]
        public string MajorValue { get; set; }

        [DataMember(Name = "display")]
        public string Display { get; set; }
    }
}