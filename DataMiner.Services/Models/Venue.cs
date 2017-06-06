using System.Runtime.Serialization;

namespace DataMiner.Services.Models
{
    [DataContract]
    public class Venue
    {
        [DataMember(Name = "user_id")]
        public string UserId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "longitude")]
        public string Longitude { get; set; }

        [DataMember(Name = "venue_profile_id")]
        public int VenueProfileId { get; set; }

        [DataMember(Name = "address")]
        public Address Address { get; set; }

        [DataMember(Name = "latitude")]
        public string Latitude { get; set; }

        [DataMember(Name = "organizer_id")]
        public string OrganizerId { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }
    }
}