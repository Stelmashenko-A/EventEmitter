namespace EventEmitter.Core.Query
{
    public interface IQueryBus
    {
        TResult Ask<TQuery, TResult>(TQuery query)
            where TQuery : IQuery;
    }
}