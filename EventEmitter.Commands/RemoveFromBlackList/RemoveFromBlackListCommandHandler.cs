using System.Linq;
using EventEmitter.Core.Command;
using EventEmitter.Storage;
using LinqToDB;

namespace EventEmitter.Commands.RemoveFromBlackList
{
    public class RemoveFromBlackListCommandHandler : ICommandHandler<RemoveFromBlackListCommand>
    {
        public void Execute(RemoveFromBlackListCommand command)
        {
            using (var db = new EventEmitterDatabase())
            {
                db.StopListRecords.Where(x =>
                    command.EventId == x.EventId &&
                    command.Users.Contains(x.UserAccountId))
                    .Delete();
            }
        }
    }
}