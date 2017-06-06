using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataMiner.ModelGenerator.Tokens;

namespace DataMiner.ModelGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var strs= f.Split(new string[] { "[DataContract]" }, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i<strs.Length;i++)
            {
                strs[i] = strs[i].Trim();
                strs[i] = "[DataContract]" + strs[i];

            }
            var data = strs.ToList();
            data.Remove("[DataContract]");
            var classes = new List<ClassToken>();
            foreach (var s in data)
            {
                classes.Add(new ClassToken(s));

            }
            var mapper = new CamelCaseService();
            foreach (var classToken in classes)
            {
                foreach (var propertyToken in classToken.Properties)
                {
                    var att = new AttributeToken($"[DataMember(Name = \"{propertyToken.Name}\")]");
                    propertyToken.Attributes.Add(att);
                    propertyToken.Name = mapper.FromUnderScore(propertyToken.Name);
                }
            }
            var sb = new StringBuilder();
            foreach (var classToken in classes)
            {
                sb.Append(classToken);
            }
            Console.WriteLine(sb);
            var attr = new AttributeToken("[ATT(fg=\"qwe\")]");
            Console.ReadKey();
        }

        const string f1 = @"[DataContract]
    public class Venue
    {
        public string user_id { get; set; }
        public string name { get; set; }
        public string longitude { get; set; }
        public int venue_profile_id { get; set; }
        public Address address { get; set; }
        public string latitude { get; set; }
        public string organizer_id { get; set; }
        public string id { get; set; }
    }";
        const string f2 = @"
    [DataContract]
    public class Venue
    {
        public string user_id { get; set; }
        public string name { get; set; }
        public string longitude { get; set; }
        public int venue_profile_id { get; set; }
        public Address address { get; set; }
        public string latitude { get; set; }
        public string organizer_id { get; set; }
        public string id { get; set; }
    }
    [DataContract]
    public class Event
    {
        public Subcategory2 subcategory { get; set; }
        public string locale { get; set; }
        public string clickEventCheckpoint { get; set; }
        public int rank { get; set; }
        public string currency { get; set; }
        public string date_header { get; set; }
        public Logo logo { get; set; }
        public Organizer organizer { get; set; }
        public string id { get; set; }
        public TicketAvailability ticket_availability { get; set; }
        public Category2 category { get; set; }
        public string venue_id { get; set; }
        public string user_id { get; set; }
        public Start start { get; set; }
        public string logo_id { get; set; }
        public string source { get; set; }
        public bool listed { get; set; }
        public bool is_series { get; set; }
        public UrgencySignals urgency_signals { get; set; }
        public bool hide_end_date { get; set; }
        public string status { get; set; }
        public Description description { get; set; }
        public Format2 format { get; set; }
        public int num_in_series { get; set; }
        public bool is_free { get; set; }
        public bool is_series_parent { get; set; }
        public string price_range { get; set; }
        public string style_id { get; set; }
        public string tld { get; set; }
        public End end { get; set; }
        public Name name { get; set; }
        public string language { get; set; }
        public string url { get; set; }
        public string type { get; set; }
        public Venue venue { get; set; }
        public bool is_locked { get; set; }
        public bool shareable { get; set; }
        public bool capacity_is_custom { get; set; }
        public bool online_event { get; set; }
        public string organizer_id { get; set; }
        public string subcategory_id { get; set; }
        public string format_id { get; set; }
        public string category_id { get; set; }
        public string vanity_url { get; set; }
    }";
        const string f = @" [DataContract]
    public class Pagination
    {
        public string page_summary { get; set; }
        public int object_count { get; set; }
        public int page_count { get; set; }
        public int page_number { get; set; }
        public int page_size { get; set; }
    }
    [DataContract]
    public class MetaInfo
    {
        public string sort { get; set; }
        public string where { get; set; }
        public string what { get; set; }
        public int nb_events_found { get; set; }
        public int nb_events_per_page { get; set; }
        public int current_version { get; set; }
        public List<object> suggestions { get; set; }
        public int total_pages { get; set; }
        public int page { get; set; }
    }
    [DataContract]
    public class Date
    {
        public int total_events_found { get; set; }
        public bool selected { get; set; }
        public string value { get; set; }
        public string label { get; set; }
    }
    [DataContract]
    public class Subcategory
    {
        public int total_events_found { get; set; }
        public bool selected { get; set; }
        public string value { get; set; }
        public string label { get; set; }
    }
    [DataContract]
    public class Format
    {
        public int total_events_found { get; set; }
        public bool selected { get; set; }
        public string value { get; set; }
        public string label { get; set; }
    }
    [DataContract]
    public class Price
    {
        public int total_events_found { get; set; }
        public bool selected { get; set; }
        public string value { get; set; }
        public string label { get; set; }
    }
    [DataContract]
    public class Category
    {
        public int total_events_found { get; set; }
        public bool selected { get; set; }
        public string value { get; set; }
        public string label { get; set; }
    }
    [DataContract]
    public class FiltersData
    {
        public List<Date> dates { get; set; }
        public List<Subcategory> subcategories { get; set; }
        public List<Format> formats { get; set; }
        public List<Price> prices { get; set; }
        public List<object> cities { get; set; }
        public List<Category> categories { get; set; }
    }
    [DataContract]
    public class DateRange
    {
        public string start_date { get; set; }
        public string end_date { get; set; }
    }
    [DataContract]
    public class Coordinates
    {
        public string slat { get; set; }
        public object vp_sw_latitude { get; set; }
        public object vp_sw_longitude { get; set; }
        public object vp_ne_latitude { get; set; }
        public string slng { get; set; }
        public object vp_ne_longitude { get; set; }
    }
    [DataContract]
    public class ParentCategory
    {
        public List<object> subcategories { get; set; }
        public string short_name_localized { get; set; }
        public string name { get; set; }
        public string short_name { get; set; }
        public string name_localized { get; set; }
        public string id { get; set; }
    }
    [DataContract]
    public class Subcategory2
    {
        public ParentCategory parent_category { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }
    [DataContract]
    public class Logo
    {
        public string url { get; set; }
        public string edge_color { get; set; }
    }
    [DataContract]
    public class Logo2
    {
        public string url { get; set; }
        public string id { get; set; }
    }
    [DataContract]
    public class Organizer
    {
        public string user_id { get; set; }
        public string url { get; set; }
        public string logo_id { get; set; }
        public Logo2 logo { get; set; }
        public string facebook { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string website { get; set; }
        public string short_name { get; set; }
        public string twitter { get; set; }
        public string vanity_url { get; set; }
    }
    [DataContract]
    public class MinimumTicketPriceRounded
    {
        public string currency { get; set; }
        public string display { get; set; }
        public int value { get; set; }
    }
    [DataContract]
    public class MaximumTicketPriceRounded
    {
        public string currency { get; set; }
        public string display { get; set; }
        public int value { get; set; }
    }
    [DataContract]
    public class MaximumTicketPrice
    {
        public string currency { get; set; }
        public int value { get; set; }
        public string major_value { get; set; }
        public string display { get; set; }
    }
    [DataContract]
    public class MinimumTicketPrice
    {
        public string currency { get; set; }
        public int value { get; set; }
        public string major_value { get; set; }
        public string display { get; set; }
    }
    [DataContract]
    public class TicketAvailability
    {
        public MinimumTicketPriceRounded minimum_ticket_price_rounded { get; set; }
        public MaximumTicketPriceRounded maximum_ticket_price_rounded { get; set; }
        public int remaining_capacity { get; set; }
        public MaximumTicketPrice maximum_ticket_price { get; set; }
        public int num_ticket_classes { get; set; }
        public bool has_available_hidden_tickets { get; set; }
        public bool waitlist_available { get; set; }
        public MinimumTicketPrice minimum_ticket_price { get; set; }
        public bool waitlist_enabled { get; set; }
        public bool has_available_tickets { get; set; }
        public string common_sales_end_date { get; set; }
        public bool is_sold_out { get; set; }
        public int quantity_sold { get; set; }
    }
    [DataContract]
    public class Category2
    {
        public List<object> subcategories { get; set; }
        public string short_name_localized { get; set; }
        public string name { get; set; }
        public string short_name { get; set; }
        public string name_localized { get; set; }
        public string id { get; set; }
    }
    [DataContract]
    public class Start
    {
        public string utc { get; set; }
        public string date_header { get; set; }
        public string timezone { get; set; }
        public string local { get; set; }
        public string formatted_time { get; set; }
    }
    [DataContract]
    public class PopularByOrders
    {
        public object reason { get; set; }
    }
    [DataContract]
    public class UrgencySignals
    {
        public PopularByOrders popular_by_orders { get; set; }
    }
    [DataContract]
    public class Description
    {
        public string text { get; set; }
        public string html { get; set; }
    }
    [DataContract]
    public class Format2
    {
        public string short_name_localized { get; set; }
        public string name { get; set; }
        public string short_name { get; set; }
        public string name_localized { get; set; }
        public string schema_url { get; set; }
        public string id { get; set; }
    }
    [DataContract]
    public class End
    {
        public string timezone { get; set; }
        public string local { get; set; }
        public string utc { get; set; }
    }
    [DataContract]
    public class Name
    {
        public string text { get; set; }
    }
    [DataContract]
    public class Address
    {
        public string city { get; set; }
        public string country { get; set; }
        public string region { get; set; }
        public string longitude { get; set; }
        public string localized_address_display { get; set; }
        public string postal_code { get; set; }
        public string latitude { get; set; }
        public List<string> localized_multi_line_address_display { get; set; }
        public string localized_area_display { get; set; }
        public string address_1 { get; set; }
    }
    [DataContract]
    public class Venue
    {
        public string user_id { get; set; }
        public string name { get; set; }
        public string longitude { get; set; }
        public int venue_profile_id { get; set; }
        public Address address { get; set; }
        public string latitude { get; set; }
        public string organizer_id { get; set; }
        public string id { get; set; }
    }
    [DataContract]
    public class Event
    {
        public Subcategory2 subcategory { get; set; }
        public string locale { get; set; }
        public string clickEventCheckpoint { get; set; }
        public int rank { get; set; }
        public string currency { get; set; }
        public string date_header { get; set; }
        public Logo logo { get; set; }
        public Organizer organizer { get; set; }
        public string id { get; set; }
        public TicketAvailability ticket_availability { get; set; }
        public Category2 category { get; set; }
        public string venue_id { get; set; }
        public string user_id { get; set; }
        public Start start { get; set; }
        public string logo_id { get; set; }
        public string source { get; set; }
        public bool listed { get; set; }
        public bool is_series { get; set; }
        public UrgencySignals urgency_signals { get; set; }
        public bool hide_end_date { get; set; }
        public string status { get; set; }
        public Description description { get; set; }
        public Format2 format { get; set; }
        public int num_in_series { get; set; }
        public bool is_free { get; set; }
        public bool is_series_parent { get; set; }
        public string price_range { get; set; }
        public string style_id { get; set; }
        public string tld { get; set; }
        public End end { get; set; }
        public Name name { get; set; }
        public string language { get; set; }
        public string url { get; set; }
        public string type { get; set; }
        public Venue venue { get; set; }
        public bool is_locked { get; set; }
        public bool shareable { get; set; }
        public bool capacity_is_custom { get; set; }
        public bool online_event { get; set; }
        public string organizer_id { get; set; }
        public string subcategory_id { get; set; }
        public string format_id { get; set; }
        public string category_id { get; set; }
        public string vanity_url { get; set; }
    }
    
    [DataContract]
    public class RootObject
    {
        public Pagination pagination { get; set; }
        public MetaInfo meta_info { get; set; }
        public string header_title { get; set; }
        public FiltersData filters_data { get; set; }
        public string error_message { get; set; }
        public object polygon_coordinates { get; set; }
        public string city_description { get; set; }
        public string canonical_url { get; set; }
        public DateRange date_range { get; set; }
        public bool search_error { get; set; }
        public Coordinates coordinates { get; set; }
        public string location { get; set; }
        public List<object> top_matches { get; set; }
        public string page_title { get; set; }
        public string nye_link { get; set; }
        public List<Event> events { get; set; }
        public string result_description { get; set; }
    }";
    }
}
