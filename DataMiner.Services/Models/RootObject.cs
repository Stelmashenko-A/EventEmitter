using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataMiner.Services.Models
{
    [DataContract]
    public class RootObject
    {
        public string Id { get; set; }

        [DataMember(Name = "pagination")]
        public Pagination Pagination { get; set; }

        [DataMember(Name = "meta_info")]
        public MetaInfo MetaInfo { get; set; }

        [DataMember(Name = "header_title")]
        public string HeaderTitle { get; set; }

        [DataMember(Name = "filters_data")]
        public FiltersData FiltersData { get; set; }

        [DataMember(Name = "error_message")]
        public string ErrorMessage { get; set; }

        [DataMember(Name = "polygon_coordinates")]
        public object PolygonCoordinates { get; set; }

        [DataMember(Name = "city_description")]
        public string CityDescription { get; set; }

        [DataMember(Name = "canonical_url")]
        public string CanonicalUrl { get; set; }

        [DataMember(Name = "date_range")]
        public DateRange DateRange { get; set; }

        [DataMember(Name = "search_error")]
        public bool SearchError { get; set; }

        [DataMember(Name = "coordinates")]
        public Coordinates Coordinates { get; set; }

        [DataMember(Name = "location")]
        public string Location { get; set; }

        [DataMember(Name = "top_matches")]
        public List<object> TopMatches { get; set; }

        [DataMember(Name = "page_title")]
        public string PageTitle { get; set; }

        [DataMember(Name = "nye_link")]
        public string NyeLink { get; set; }

        [DataMember(Name = "events")]
        public List<Event> Events { get; set; }

        [DataMember(Name = "result_description")]
        public string ResultDescription { get; set; }
    }
}