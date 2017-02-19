using System;

namespace EventEmitter.Storage.Models
{
    public class UserType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Users { get; set; }
        public int ClaimsNumber { get; set; }
    }
}
