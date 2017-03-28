using System;
using System.Runtime.Serialization;

namespace EventEmitter.Queries.User
{
    [DataContract]
    public class User
    {
        [DataMember(Name = "id")]
        public Guid UserId { get; set; }

        [DataMember(Name = "name")]
        public string UserName { get; set; }

    }
}