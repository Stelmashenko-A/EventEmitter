using System.Runtime.Serialization;

namespace DataMiner.Services.Models
{
    [DataContract]
    public class Logo
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "edge_color")]
        public string EdgeColor { get; set; }
    }
}