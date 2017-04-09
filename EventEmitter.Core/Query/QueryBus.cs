using System;
using System.Web.Mvc;

namespace EventEmitter.Core.Query
{
    public class QueryBus : IQueryBus
    {
        private readonly IDependencyResolver _resolver;

        public QueryBus(IDependencyResolver resolver)
        {
            _resolver = resolver;
        }

        public TResult Execute<TQuery, TResult>(TQuery query)
            where TQuery : IQuery
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            var handler = _resolver.GetService(typeof(IQueryHandler<TQuery, TResult>)) as IQueryHandler<TQuery, TResult>;

            if (handler == null)
            {
                throw new QueryHandlerNotFoundException(typeof(TQuery));
            }

            return handler.Execute(query);
        }
    }
}