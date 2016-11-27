using System;
using RegistrationType = EventEmitter.Storage.POCO.Enums.RegistrationType;

namespace EventEmitter.Storage.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int Slots { get; set; }
        public int Price { get; set; }
        public double TimeStamp { get; set; }
        public Guid EventTypeId { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
        public RegistrationType Type { get; set; }
    }
}
