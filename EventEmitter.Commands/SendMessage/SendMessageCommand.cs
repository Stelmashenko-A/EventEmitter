using System;
using System.Runtime.Serialization;
using EventEmitter.Core.Command;
using EventEmitter.Storage;
using LinqToDB;

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

    public class SendMessageCommandHandrler : ICommandHandler<SendMessageCommand>
    {
        public void Execute(SendMessageCommand command)
        {
            using (var db = new EventEmitterDatabase())
            {
                db.Insert(new Storage.POCO.Message
                {
                    EventId = command.Event,
                    Text = command.Text,
                    Time = DateTime.Now,
                    UserAccountId = command.Author
                });
            }
        }
    }
}
