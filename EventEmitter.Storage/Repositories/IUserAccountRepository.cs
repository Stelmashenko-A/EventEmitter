using System.Collections.Generic;
using EventEmitter.Storage.POCO;

namespace EventEmitter.Storage.Repositories
{
    public interface IUserAccountRepository : IRepository<UserAccount>
    {
        //IEnumerable<UserAccount> Contains(Event @event, EventType eventType);
        UserAccount Get(string loginProvider, string providerKey);
    }
}