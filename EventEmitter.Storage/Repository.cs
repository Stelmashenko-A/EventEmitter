using System;
using LinqToDB;
using System.Linq;


namespace EventEmitter.Storage
{
    public class Repository<T> : IRepository<T> where T : class, IPoco
    {
        public void Insert(T item)
        {
            using (var db = new EventEmitterDatabase())
            {
                item.Id = (Guid) db.InsertWithIdentity(item);
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
    }
}