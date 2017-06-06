using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataMiner.Services.Models
{
    [DataContract]
    public class Address
    {
        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "country")]
        public string Country { get; set; }

        [DataMember(Name = "region")]
        public string Region { get; set; }

        [DataMember(Name = "longitude")]
        public string Longitude { get; set; }

        [DataMember(Name = "localized_address_display")]
        public string LocalizedAddressDisplay { get; set; }

        [DataMember(Name = "postal_code")]
        public string PostalCode { get; set; }

        [DataMember(Name = "latitude")]
        public string Latitude { get; set; }

        [DataMember(Name = "localized_multi_line_address_display")]
        public List<string> LocalizedMultiLineAddressDisplay { get; set; }

        [DataMember(Name = "localized_area_display")]
        public string LocalizedAreaDisplay { get; set; }

        [DataMember(Name = "address_1")]
        public string Address1 { get; set; }
    }
}