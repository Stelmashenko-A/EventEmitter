using System.Linq;
using System.Web.Mvc;

namespace EventEmitter.Core.Query
{
    public class QueryBus : IQueryBus
    {
        public Context Context { get; set; }
        public readonly IQueryDispatcher QueryDispatcher;

        public TResult Ask<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            Validate(query);
            return QueryDispatcher.Execute<TQuery, TResult>(query);
        }

        protected readonly IDependencyResolver DependencyResolver;

        public QueryBus(IDependencyResolver dependencyResolver, IQueryDispatcher queryDispatcher)
        {
            DependencyResolver = dependencyResolver;
            QueryDispatcher = queryDispatcher;
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