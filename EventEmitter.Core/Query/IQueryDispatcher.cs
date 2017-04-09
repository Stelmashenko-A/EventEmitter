namespace EventEmitter.Core.Query
{
    public interface IQueryDispatcher
    {
        TResult Ask<TQuery, TResult>(TQuery query)
            where TQuery : IQuery;
    }
}