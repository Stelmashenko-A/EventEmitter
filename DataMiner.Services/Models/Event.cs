using System.Runtime.Serialization;

namespace DataMiner.Services.Models
{
    [DataContract]
    public class Event
    {
        [DataMember(Name = "subcategory")]
        public EventSubcategory Subcategory { get; set; }

        [DataMember(Name = "locale")]
        public string Locale { get; set; }

        [DataMember(Name = "clickEventCheckpoint")]
        public string Clickeventcheckpoint { get; set; }

        [DataMember(Name = "rank")]
        public int Rank { get; set; }

        [DataMember(Name = "currency")]
        public string Currency { get; set; }

        [DataMember(Name = "date_header")]
        public string DateHeader { get; set; }

        [DataMember(Name = "logo")]
        public Logo Logo { get; set; }

        [DataMember(Name = "organizer")]
        public Organizer Organizer { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "ticket_availability")]
        public TicketAvailability TicketAvailability { get; set; }

        [DataMember(Name = "category")]
        public EventCategory Category { get; set; }

        [DataMember(Name = "venue_id")]
        public string VenueId { get; set; }

        [DataMember(Name = "user_id")]
        public string UserId { get; set; }

        [DataMember(Name = "start")]
        public Start Start { get; set; }

        [DataMember(Name = "logo_id")]
        public string LogoId { get; set; }

        [DataMember(Name = "source")]
        public string Source { get; set; }

        [DataMember(Name = "listed")]
        public bool Listed { get; set; }

        [DataMember(Name = "is_series")]
        public bool IsSeries { get; set; }

        [DataMember(Name = "urgency_signals")]
        public UrgencySignals UrgencySignals { get; set; }

        [DataMember(Name = "hide_end_date")]
        public bool HideEndDate { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "description")]
        public Description Description { get; set; }

        [DataMember(Name = "format")]
        public EventFormat Format { get; set; }

        [DataMember(Name = "num_in_series")]
        public int NumInSeries { get; set; }

        [DataMember(Name = "is_free")]
        public bool IsFree { get; set; }

        [DataMember(Name = "is_series_parent")]
        public bool IsSeriesParent { get; set; }

        [DataMember(Name = "price_range")]
        public string PriceRange { get; set; }

        [DataMember(Name = "style_id")]
        public string StyleId { get; set; }

        [DataMember(Name = "tld")]
        public string Tld { get; set; }

        [DataMember(Name = "end")]
        public End End { get; set; }

        [DataMember(Name = "name")]
        public Name Name { get; set; }

        [DataMember(Name = "language")]
        public string Language { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "venue")]
        public Venue Venue { get; set; }

        [DataMember(Name = "is_locked")]
        public bool IsLocked { get; set; }

        [DataMember(Name = "shareable")]
        public bool Shareable { get; set; }

        [DataMember(Name = "capacity_is_custom")]
        public bool CapacityIsCustom { get; set; }

        [DataMember(Name = "online_event")]
        public bool OnlineEvent { get; set; }

        [DataMember(Name = "organizer_id")]
        public string OrganizerId { get; set; }

        [DataMember(Name = "subcategory_id")]
        public string SubcategoryId { get; set; }

        [DataMember(Name = "format_id")]
        public string FormatId { get; set; }

        [DataMember(Name = "category_id")]
        public string CategoryId { get; set; }

        [DataMember(Name = "vanity_url")]
        public string VanityUrl { get; set; }
    }
}