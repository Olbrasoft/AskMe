using System.Linq;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Mapping;

namespace Olbrasoft.Querying.Mapping.EntityFrameworkCore
{
    public abstract class QueryHandlerWithProjectorAndDbContext<TQuery, TResult, TEntity, TDbContext> : QueryHandlerWithProjector<TQuery, TResult> where TQuery : IQuery<TResult> where TEntity : class where TDbContext : DbContext
    {
        protected TDbContext Context;

        protected QueryHandlerWithProjectorAndDbContext(IProjection projector, TDbContext context) : base(projector)
        {
            Context = context;
        }

        protected virtual IQueryable<TEntity> Entities()
        {
            return Context.Set<TEntity>();
        }
    }
}