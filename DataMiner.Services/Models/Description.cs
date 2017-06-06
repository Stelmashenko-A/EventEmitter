using System.Runtime.Serialization;

namespace DataMiner.Services.Models
{
    [DataContract]
    public class Description
    {
        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "html")]
        public string Html { get; set; }
    }
}