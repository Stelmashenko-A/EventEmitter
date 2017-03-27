using System;
using EventEmitter.Core.Command;
using EventEmitter.Semantic;
using EventEmitter.Storage;
using LinqToDB;
using Ninject;

namespace EventEmitter.Commands.SendMessage
{
    public class SendMessageCommandHandler : ICommandHandler<SendMessageCommand>
    {
        [Inject]
        public ISentimenClassifier Classifier { get; set; }

        public void Execute(SendMessageCommand command)
        {
            using (var db = new EventEmitterDatabase())
            {
                db.Insert(new Storage.POCO.Message
                {
                    EventId = command.Event,
                    Text = command.Text,
                    Time = DateTime.Now,
                    UserAccountId = command.Author,
                    Sentiment = Classifier.Classify(command.Text) > 0 ? 1 : -1
                });
            } 
        }
    }
}