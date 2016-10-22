using System;

namespace EventEmitter.UserServices.Models
{
    public class User
    {   
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LoginProvider { get; set; }

        public string LoginProviderKey { get; set; }

        public string Base64Secret { get; set; }

        public Guid UserTypeId { get; set; }
    }
}