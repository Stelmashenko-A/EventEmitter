using System;
using EventEmitter.Storage.POCO;
using LinqToDB;
using System.Linq;


namespace EventEmitter.Storage
{

    public class UserAccountRepository : IRepository<UserAccount>
    {
        public void Insert(UserAccount item)
        {
            using (var db = new EventEmitterDatabase())
            {
                item.UserAccountId = (Guid)db.InsertWithIdentity(item);
            }
        }

        public void Update(UserAccount item)
        {
            using (var db = new EventEmitterDatabase())
            {
                db.Update(item);
            }
        }

        public void Delete(UserAccount item)
        {
            using (var db = new EventEmitterDatabase())
            {
                db.Delete(item);
            }
        }

        public UserAccount Get(Guid id)
        {
            using (var db = new EventEmitterDatabase())
            {
                var query = from p in db.UserAccounts
                    where p.UserAccountId == id
                    select p;

                return query.FirstOrDefault();
            }
        }

        public UserAccount Get(string loginPovider, string loginProviderKey)
        {
            using (var db = new EventEmitterDatabase())
            {
                var query = from p in db.UserAccounts
                    where p.LoginProvider == loginPovider
                          && p.LoginProviderKey == loginProviderKey
                    select p;

                return query.FirstOrDefault();
            }
        }
    }
}