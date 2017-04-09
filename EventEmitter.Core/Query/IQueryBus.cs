namespace EventEmitter.Core.Query
{
    public interface IQueryBus
    {
        TResult Execute<TQuery, TResult>(TQuery query)
            where TQuery : IQuery;
    }
}