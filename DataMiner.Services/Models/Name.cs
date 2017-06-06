using System.Runtime.Serialization;

namespace DataMiner.Services.Models
{
    [DataContract]
    public class Name
    {
        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}