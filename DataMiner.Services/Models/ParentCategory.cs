using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataMiner.Services.Models
{
    [DataContract]
    public class ParentCategory
    {
        [DataMember(Name = "subcategories")]
        public List<object> Subcategories { get; set; }

        [DataMember(Name = "short_name_localized")]
        public string ShortNameLocalized { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "short_name")]
        public string ShortName { get; set; }

        [DataMember(Name = "name_localized")]
        public string NameLocalized { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }
    }
}