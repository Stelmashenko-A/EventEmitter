using System;
using System.Linq;
using EventEmitter.Core.Command;
using EventEmitter.Storage;
using LinqToDB;

namespace EventEmitter.Commands.AddToBlackList
{
    public class AddToBlackListCommandHandler : ICommandHandler<AddToBlackListCommand>
    {
        public void Execute(AddToBlackListCommand command)
        {
            using (var db = new EventEmitterDatabase())
            {
                db.Insert(new Storage.POCO.StopListRecord
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