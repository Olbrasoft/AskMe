using System.Linq;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Querying;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.QueryHandlers
{
    public abstract class QueryHandler<TQuery, TEntity, TResult> : Handler<TQuery, IQueryable<TEntity>, TResult>
        where TQuery : IQuery<TResult> where TEntity : class
    {
        protected AskDbContext Context { get; }

        protected override IQueryable<TEntity> GetSource()
        {
            return Context.Set<TEntity>();
        }

        protected QueryHandler(AskDbContext context, IProjection projector) : base(projector)
        {
            Context = context;
        }
    }
}