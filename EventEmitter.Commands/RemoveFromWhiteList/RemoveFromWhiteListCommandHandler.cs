using System.Linq;
using EventEmitter.Core.Command;
using EventEmitter.Storage;
using LinqToDB;

namespace EventEmitter.Commands.RemoveFromWhiteList
{
    public class RemoveFromWhiteListCommandHandler : ICommandHandler<RemoveFromWhiteListCommand>
    {
        public void Execute(RemoveFromWhiteListCommand command)
        {
            using (var db = new EventEmitterDatabase())
            {
                db.WhiteListRecords.Where(x =>
                    command.EventId == x.EventId &&
                    command.Users.Contains(x.UserAccountId))
                    .Delete();
            }
        }
    }
}