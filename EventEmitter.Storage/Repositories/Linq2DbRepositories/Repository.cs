using System;
using System.Linq;
using System.Linq.Expressions;
using LinqToDB;

namespace EventEmitter.Storage.Repositories.Linq2DbRepositories
{
    public class Repository<T> : IRepository<T> where T : class, IPoco
    {
        public void Insert(T item)
        {
            using (var db = new EventEmitterDatabase())
            {
                db.Insert(item);
            }
        }

        public void Update(T item)
        {
            using (var db = new EventEmitterDatabase())
            {
                db.Update(item);
            }
        }

        public void Delete(T item)
        {
            using (var db = new EventEmitterDatabase())
            {
                db.Delete(item);
            }
        }

        public T Get(Guid id)
        {
            using (var db = new EventEmitterDatabase())
            {
                var query = db.GetTable<T>().Where(x => x.Id == id);
                return query.FirstOrDefault();
            }
        }

        public IQueryable<T> Get(IStrategy<T> strategy)
        {
            using (var db = new EventEmitterDatabase())
            {
                return strategy.Execute(db.GetTable<T>().AsQueryable());
            }
        }

        public TOut Get<TOut>(IStrategy<T, TOut> strategy)
        {
            using (var db = new EventEmitterDatabase())
            {
                return strategy.Execute(db.GetTable<T>().AsQueryable());
            }
        }

        public bool Contains(Expression<Func<T,bool>> predicate)
        {
            using (var db = new EventEmitterDatabase())
            {
                return db.GetTable<T>().Any(predicate);
            }
        }
    }
}

