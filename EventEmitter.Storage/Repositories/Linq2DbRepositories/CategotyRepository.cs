using System.Collections.Generic;
using System.Linq;
using EventEmitter.Storage.POCO;

namespace EventEmitter.Storage.Repositories.Linq2DbRepositories
{
    public class CategotyRepository : Repository<Category>, ICategoryRepository
    {
        public IEnumerable<Category> GetAll()
        {
            using (var db = new EventEmitterDatabase())
            {
                return db.Categories.ToList();
            }
        }

        public Category Get(string code)
        {
            using (var db = new EventEmitterDatabase())
            {
                return db.Categories.FirstOrDefault(cat => cat.Code == code);
            }
        }
    }
}