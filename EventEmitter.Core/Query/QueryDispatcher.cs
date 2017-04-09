using System.Linq;
using System.Web.Mvc;

namespace EventEmitter.Core.Query
{
    public class QueryDispatcher : IQueryDispatcher
    {
        public Context Context { get; set; }
        public readonly IQueryBus QueryBus;

        public TResult Ask<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            Validate(query);
            return QueryBus.Execute<TQuery, TResult>(query);
        }

        protected readonly IDependencyResolver DependencyResolver;

        public QueryDispatcher(IDependencyResolver dependencyResolver, IQueryBus queryBus)
        {
            DependencyResolver = dependencyResolver;
            QueryBus = queryBus;
        }

        protected void Validate<TQuery>(TQuery query) where TQuery : IQuery
        {
            var validators = DependencyResolver.GetServices(typeof(IQueryValidator<TQuery>)).Select(x => x as IQueryValidator<TQuery>);
            foreach (var validator in validators.Where(validator => !validator.IsValid(query, Context)))
            {
                throw new QueryValidationException(query.GetType().FullName + " falid on " + validator.GetType().FullName);
            }
        }
    }
}