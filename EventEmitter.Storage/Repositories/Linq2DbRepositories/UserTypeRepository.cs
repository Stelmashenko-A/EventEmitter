using System.Collections.Generic;
using System.Linq;
using EventEmitter.Storage.POCO;

namespace EventEmitter.Storage.Repositories.Linq2DbRepositories
{
    public class UserTypeRepository : Repository<UserType>, IUserTypeRepository
    {
        public IEnumerable<UserType> GetAll()
        {
            using (var db = new EventEmitterDatabase())
            {
                return db.UserTypes.ToList();
            }
        }
    }
}