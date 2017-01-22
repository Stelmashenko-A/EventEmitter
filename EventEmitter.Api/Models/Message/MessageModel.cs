using System;

namespace EventEmitter.Api.Models.Message
{
    public class MessageModel
    {
        public string text { get; set; }
        public Guid eventId { get; set; }
    }
}