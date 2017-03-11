namespace EventEmitter.Core.Query
{
    public interface IQueryValidator<in TQuery> where TQuery : IQuery
    {
        bool IsValid(TQuery command, Context context);
    }
}