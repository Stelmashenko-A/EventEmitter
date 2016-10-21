using System;

namespace EventEmitter.UserServices.Models
{
    public class Registration
    {
        public Guid Id { get; set; }

        public RegistrationType RegistrationType { get; set; }

        public Guid UserAccountId { get; set; }

        public Guid EventId { get; set; }
    }
}