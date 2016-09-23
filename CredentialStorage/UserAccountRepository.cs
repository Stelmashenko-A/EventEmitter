using System;
using System.Linq;
using LinqToDB;

namespace CredentialStorage
{
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