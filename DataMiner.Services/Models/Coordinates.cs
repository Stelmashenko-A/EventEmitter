using System.Runtime.Serialization;

namespace DataMiner.Services.Models
{
    [DataContract]
    public class Coordinates
    {
        [DataMember(Name = "slat")]
        public string Slat { get; set; }

        [DataMember(Name = "vp_sw_latitude")]
        public object VpSwLatitude { get; set; }

        [DataMember(Name = "vp_sw_longitude")]
        public object VpSwLongitude { get; set; }

        [DataMember(Name = "vp_ne_latitude")]
        public object VpNeLatitude { get; set; }

        [DataMember(Name = "slng")]
        public string Slng { get; set; }

        [DataMember(Name = "vp_ne_longitude")]
        public object VpNeLongitude { get; set; }
    }
}