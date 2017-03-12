using System;

namespace EventEmitter.Queries.Registration
{
    public class Event
    {
        public string RegistrationType { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public int Price { get; set; }
        public Guid RegistrationId { get; set; }
        public Guid EventId { get; set; }
    }
}