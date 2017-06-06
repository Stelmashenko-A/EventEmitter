using System.Runtime.Serialization;

namespace DataMiner.Services.Models
{
    [DataContract]
    public class EventSubcategory
    {
        [DataMember(Name = "parent_category")]
        public ParentCategory ParentCategory { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }
    }
}