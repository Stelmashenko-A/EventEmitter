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
}