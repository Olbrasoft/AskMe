using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Olbrasoft.Querying.EntityFrameworkCore
{
    public abstract class QueryHandlerWithDbContext<TQuery, TResult, TEntity, TContext> : QueryHandler<TQuery, TResult> where TQuery : IQuery<TResult> where TContext : DbContext where TEntity : class
    {
        protected readonly TContext Context;

        protected QueryHandlerWithDbContext(TContext context)
        {
            Context = context;
        }

        protected IQueryable<TEntity> Entities()
        {
            return Context.Set<TEntity>();
        }
    }
}