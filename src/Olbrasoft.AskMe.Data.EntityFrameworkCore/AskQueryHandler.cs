using Olbrasoft.Mapping;
using Olbrasoft.Querying;
using Olbrasoft.Querying.Mapping.EntityFrameworkCore;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore
{
    public abstract class AskQueryHandler<TQuery, TResult, TEntity>:QueryHandlerWithProjectorAndDbContext<TQuery,TResult,TEntity,AskDbContext> where TQuery : IQuery<TResult> where TEntity : class
    {
        protected AskQueryHandler(IProjection projector, AskDbContext context) : base(projector, context)
        {
        }
    }
}