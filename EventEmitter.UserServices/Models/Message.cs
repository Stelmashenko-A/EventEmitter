using System;

namespace EventEmitter.UserServices.Models
{
    public class Message
    {       
        public Guid Id { get; set; }

        public string Text { get; set; }

        public DateTime Time { get; set; }

        public Guid UserAccountId { get; set; }

        public Guid EventId { get; set; }
    }
}