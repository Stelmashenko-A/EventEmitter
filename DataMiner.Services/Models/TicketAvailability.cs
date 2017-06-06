using System.Runtime.Serialization;

namespace DataMiner.Services.Models
{
    [DataContract]
    public class TicketAvailability
    {
        [DataMember(Name = "minimum_ticket_price_rounded")]
        public MinimumTicketPriceRounded MinimumTicketPriceRounded { get; set; }

        [DataMember(Name = "maximum_ticket_price_rounded")]
        public MaximumTicketPriceRounded MaximumTicketPriceRounded { get; set; }

        [DataMember(Name = "remaining_capacity")]
        public int RemainingCapacity { get; set; }

        [DataMember(Name = "maximum_ticket_price")]
        public MaximumTicketPrice MaximumTicketPrice { get; set; }

        [DataMember(Name = "num_ticket_classes")]
        public int NumTicketClasses { get; set; }

        [DataMember(Name = "has_available_hidden_tickets")]
        public bool HasAvailableHiddenTickets { get; set; }

        [DataMember(Name = "waitlist_available")]
        public bool WaitlistAvailable { get; set; }

        [DataMember(Name = "minimum_ticket_price")]
        public MinimumTicketPrice MinimumTicketPrice { get; set; }

        [DataMember(Name = "waitlist_enabled")]
        public bool WaitlistEnabled { get; set; }

        [DataMember(Name = "has_available_tickets")]
        public bool HasAvailableTickets { get; set; }

        [DataMember(Name = "common_sales_end_date")]
        public string CommonSalesEndDate { get; set; }

        [DataMember(Name = "is_sold_out")]
        public bool IsSoldOut { get; set; }

        [DataMember(Name = "quantity_sold")]
        public int QuantitySold { get; set; }
    }
}