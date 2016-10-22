using System.Collections.Generic;
using EventEmitter.Storage.POCO;

namespace EventEmitter.Storage.Repositories
{
    public interface IUserAccountRepository : IRepository<UserAccount>
    {
        IEnumerable<UserAccount> Get(Event @event, EventType eventType);
    }
}