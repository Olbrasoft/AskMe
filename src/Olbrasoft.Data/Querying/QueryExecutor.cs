using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Querying
{
    public class QueryExecutor<TQuery, TResult> : IQueryExecutor<TResult> where TQuery : IQuery<TResult>
    {
        private readonly IQueryHandler<TQuery, TResult> _queryHandler;

        public QueryExecutor(IQueryHandler<TQuery, TResult> queryHandler)
        {
            _queryHandler = queryHandler;
        }

        public TResult Execute(IQuery<TResult> query)
        {
            return _queryHandler.Handle((TQuery)query);
        }

        public Task<TResult> ExecuteAsync(IQuery<TResult> query, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _queryHandler.HandleAsync((TQuery)query, cancellationToken);
        }
    }
}