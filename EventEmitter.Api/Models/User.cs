using System;

namespace EventEmitter.Api.Models
{
    public class User
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LoginProvider { get; set; }

        public Guid UserTypeId { get; set; }

        public int Events { get; set; }

        public int Messages { get; set; }

        public int InterestedTotal { get; set; }

        public int GoTotal { get; set; }

        public int WillGo { get; set; }

        public int Interested { get; set; }
    }
}