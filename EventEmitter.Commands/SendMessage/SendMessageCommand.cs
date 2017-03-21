using System;
using System.Runtime.Serialization;
using EventEmitter.Core.Command;

namespace EventEmitter.Commands.SendMessage
{
    [DataContract]
    public class SendMessageCommand : ICommand
    {
        public Guid Author { get; set; }

        [DataMember(Name = "eventId")]
        public Guid Event { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}
