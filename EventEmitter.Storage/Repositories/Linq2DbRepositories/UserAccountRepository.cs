using System.Linq;
using EventEmitter.Storage.POCO;

namespace EventEmitter.Storage.Repositories.Linq2DbRepositories
{
    public class UserAccountRepository : Repository<UserAccount>, IUserAccountRepository
    {
        public UserAccount Get(string loginProvider, string providerKey)
        {
            using (var db = new EventEmitterDatabase())
            {
                var query = from item in db.UserAccounts
                            where item.LoginProvider == loginProvider &&
                            item.LoginProviderKey == providerKey
                            select item;
                return query.FirstOrDefault();
            }
        }
    }
}