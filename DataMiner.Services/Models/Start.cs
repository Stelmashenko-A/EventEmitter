using System.Runtime.Serialization;

namespace DataMiner.Services.Models
{
    [DataContract]
    public class Start
    {
        [DataMember(Name = "utc")]
        public string Utc { get; set; }

        [DataMember(Name = "date_header")]
        public string DateHeader { get; set; }

        [DataMember(Name = "timezone")]
        public string Timezone { get; set; }

        [DataMember(Name = "local")]
        public string Local { get; set; }

        [DataMember(Name = "formatted_time")]
        public string FormattedTime { get; set; }
    }
}