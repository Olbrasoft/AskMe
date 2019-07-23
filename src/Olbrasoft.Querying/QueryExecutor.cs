using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Querying
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

        public Task<TResult> ExecuteAsync(IQuery<TResult> query, CancellationToken token = default)
        {
            return _queryHandler.HandleAsync((TQuery)query, token);
        }
    }
}