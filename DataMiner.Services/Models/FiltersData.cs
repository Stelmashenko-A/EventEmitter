using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataMiner.Services.Models
{
    [DataContract]
    public class FiltersData
    {
        [DataMember(Name = "dates")]
        public List<Date> Dates { get; set; }

        [DataMember(Name = "subcategories")]
        public List<Subcategory> Subcategories { get; set; }

        [DataMember(Name = "formats")]
        public List<Format> Formats { get; set; }

        [DataMember(Name = "prices")]
        public List<Price> Prices { get; set; }

        [DataMember(Name = "cities")]
        public List<object> Cities { get; set; }

        [DataMember(Name = "categories")]
        public List<Category> Categories { get; set; }
    }
}