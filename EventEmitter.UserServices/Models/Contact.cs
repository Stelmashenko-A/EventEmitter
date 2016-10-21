using System;

namespace EventEmitter.UserServices.Models
{
    public class Contact
    {
        public Guid Id { get; set; }

        public Guid SenderUserId { get; set; }

        public Guid GetterUserId { get; set; }
    }
}