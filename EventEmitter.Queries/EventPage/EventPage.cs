using System;

namespace EventEmitter.Queries.EventPage
{
    public class EventPage
    {
        public Guid Id { get; set; }

        public DateTime Start { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public int Slots { get; set; }

        public int Price { get; set; }

        public double TimeStamp { get; set; }

        public EventType EventType { get; set; }

        public string Author { get; set; }

        public RegistrationType Type { get; set; }

        public string Image { get; set; }
    }
}
