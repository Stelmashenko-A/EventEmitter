using System.Runtime.Serialization;

namespace DataMiner.Services.Models
{
    [DataContract]
    public class End
    {
        [DataMember(Name = "timezone")]
        public string Timezone { get; set; }

        [DataMember(Name = "local")]
        public string Local { get; set; }

        [DataMember(Name = "utc")]
        public string Utc { get; set; }
    }
}