using System.Runtime.Serialization;

namespace DataMiner.Services.Models
{
    [DataContract]
    public class OrganizerLogo
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }
    }
}