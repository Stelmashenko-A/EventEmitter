using System;
using System.Runtime.Serialization;

namespace EventEmitter.Queries.BlackList
{
    [DataContract]
    public class BlackListRecord
    {
        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        [DataMember(Name = "user")]
        public string User { get; set; }

        [DataMember(Name = "userId")]
        public Guid UserId { get; set; }

        [DataMember(Name = "added")]
        public DateTime Added { get; set; }

        [DataMember(Name = "desc")]
        public string Description { get; set; }
    }
}