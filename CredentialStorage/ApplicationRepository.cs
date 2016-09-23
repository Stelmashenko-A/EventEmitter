using System;
using System.Linq;
using LinqToDB;

namespace CredentialStorage
{
    public class ApplicationRepository : IRepository<Application>
    {
        public void Insert(Application item)
        {
            using (var db = new AuthorizationServerDatabase())
            {
                item.ApplicationId = (Guid) db.InsertWithIdentity(item);
            }
        }

        public void Update(Application item)
        {
            using (var db = new AuthorizationServerDatabase())
            {
                db.Update(item);
            }
        }

        public void Delete(Application item)
        {
            using (var db = new AuthorizationServerDatabase())
            {
                db.Delete(item);
            }
        }

        public Application Get(Guid id)
        {
            using (var db = new AuthorizationServerDatabase())
            {
                var query = from p in db.Application
                    where p.ApplicationId == id
                    select p;

                return query.FirstOrDefault();
            }
        }
    }

    public class UserAccountRepository : IRepository<UserAccount>
    {
        public void Insert(UserAccount item)
        {
            using (var db = new AuthorizationServerDatabase())
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
    }
}