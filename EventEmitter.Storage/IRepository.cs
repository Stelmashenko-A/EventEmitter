using System;
using EventEmitter.Storage.POCO;

namespace EventEmitter.Storage
{
    public interface IRepository<T>
    {
        void Insert(T item);
        void Update(T item);
        void Delete(T id);
        T Get(Guid id);
    }

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
            using (var db = new AuthorizationServerDatabase())
            {
                db.Update(item);
            }
        }

        public void Delete(UserAccount item)
        {
            using (var db = new AuthorizationServerDatabase())
            {
                db.Delete(item);
            }
        }

        public UserAccount Get(Guid id)
        {
            using (var db = new AuthorizationServerDatabase())
            {
                var query = from p in db.UserAccount
                            where p.UserAccountId == id
                            select p;

                return query.FirstOrDefault();
            }
        }

        public UserAccount Get(string loginPovider, string loginProviderKey)
        {
            using (var db = new AuthorizationServerDatabase())
            {
                var query = from p in db.UserAccount
                            where p.LoginProvider == loginPovider
                            && p.LoginProviderKey == loginProviderKey
                            select p;

                return query.FirstOrDefault();
            }
        }
    }
}