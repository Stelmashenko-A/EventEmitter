using System.Runtime.Serialization;

namespace DataMiner.Services.Models
{
    [DataContract]
    public class Organizer
    {
        [DataMember(Name = "user_id")]
        public string UserId { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "logo_id")]
        public string LogoId { get; set; }

        [DataMember(Name = "logo")]
        public OrganizerLogo Logo { get; set; }

        [DataMember(Name = "facebook")]
        public string Facebook { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "website")]
        public string Website { get; set; }

        [DataMember(Name = "short_name")]
        public string ShortName { get; set; }

        [DataMember(Name = "twitter")]
        public string Twitter { get; set; }

        [DataMember(Name = "vanity_url")]
        public string VanityUrl { get; set; }
    }
}