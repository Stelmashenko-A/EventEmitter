using System.Runtime.Serialization;

namespace DataMiner.Services.Models
{
    [DataContract]
    public class PopularByOrders
    {
        [DataMember(Name = "reason")]
        public object Reason { get; set; }
    }
}