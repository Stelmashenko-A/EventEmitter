using System.Runtime.Serialization;

namespace DataMiner.Services.Models
{
    [DataContract]
    public class MaximumTicketPriceRounded
    {
        [DataMember(Name = "currency")]
        public string Currency { get; set; }

        [DataMember(Name = "display")]
        public string Display { get; set; }

        [DataMember(Name = "value")]
        public int Value { get; set; }
    }
}