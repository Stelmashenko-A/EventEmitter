using System.Collections.Generic;
using EventEmitter.Storage.Models;
using EventEmitter.Storage.POCO;

namespace EventEmitter.Storage.Repositories
{
    public interface IUserAccountRepository : IRepository<UserAccount>
    {
        IEnumerable<User> Get(int page, int pageSize);
        UserAccount Get(string loginProvider, string providerKey);
    }
}