using System.Linq;

namespace EventEmitter.Storage
{
    public interface IStrategy<in TIn, out TOut>
    {
        TOut Execute(IQueryable<TIn> query);
    }

    public interface IStrategy<T>
    {
        IQueryable<T> Execute(IQueryable<T> query);
    }
}