using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using EventEmitter.Core.Command;

namespace EventEmitter.Commands.RemoveFromBlackList
{
    [DataContract]
    public class RemoveFromBlackListCommand : ICommand
    {
        [DataMember(Name = "event")]
        public Guid EventId { get; set; }

        [DataMember(Name = "users")]
        public IList<Guid> Users { get; set; }
    }
}
