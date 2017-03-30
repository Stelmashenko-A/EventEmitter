using System;
using EventEmitter.Core.Command;
using EventEmitter.Storage;
using LinqToDB;

namespace EventEmitter.Commands.AddToWhiteList
{
    public class AddToWhiteListCommandHandler : ICommandHandler<AddToWhiteListCommand>
    {
        public void Execute(AddToWhiteListCommand command)
        {
            using (var db = new EventEmitterDatabase())
            {
                db.Insert(new Storage.POCO.WhiteListRecord
                {
                    EventId = command.EventId,
                    UserAccountId = command.UserId,
                    Added = DateTime.Now,
                    Description = command.Reason,
                    Id = command.Id
                });
            }
        }
    }
}