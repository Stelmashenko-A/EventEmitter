using System;

namespace EventEmitter.Api.Models.Event
{
    public class Event
    {
        public string Owner { get; set; }
        public DateTime Start { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Slots { get; set; }
        public string Image { get; set; }
    }
}