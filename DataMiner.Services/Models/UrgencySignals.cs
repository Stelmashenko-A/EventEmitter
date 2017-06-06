using System.Runtime.Serialization;

namespace DataMiner.Services.Models
{
    [DataContract]
    public class UrgencySignals
    {
        [DataMember(Name = "popular_by_orders")]
        public PopularByOrders PopularByOrders { get; set; }
    }
}