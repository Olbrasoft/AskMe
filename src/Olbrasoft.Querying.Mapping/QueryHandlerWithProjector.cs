using System.Linq;
using Olbrasoft.Mapping;

namespace Olbrasoft.Querying.Mapping
{
    public abstract class QueryHandlerWithProjector<TQuery, TResult> : QueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        private readonly IProjector _projector;

        protected QueryHandlerWithProjector(IProjector projector)
        {
            _projector = projector;
        }

        protected virtual IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source)
        {
            return _projector.ProjectTo<TDestination>(source);
        }
    }
}