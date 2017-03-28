using System;
using System.Runtime.Serialization;
using EventEmitter.Core.Command;

namespace EventEmitter.Commands.AddToBlackList
{
    [DataContract]
    public class AddToBlackListCommand : ICommand
    {
        [DataMember(Name = "user")]
        public Guid UserId { get; set; }

        [DataMember(Name = "eventId")]
        public Guid EventId { get; set; }

        [DataMember(Name = "reason")]
        public string Reason { get; set; }

        public Guid Id { get; set; }
    }
}
