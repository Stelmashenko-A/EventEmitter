using System;
using System.Linq;
using System.Linq.Expressions;

namespace EventEmitter.Storage
{
    public interface IRepository<T>
    {
        void Insert(T item);
        void Update(T item);
        void Delete(T id);
        T Get(Guid id);
        IQueryable<T> Get(IStrategy<T> strategy);
        TOut Get<TOut>(IStrategy<T, TOut> strategy);
        bool Contains(Expression<Func<T, bool>> predicate);
    }
}