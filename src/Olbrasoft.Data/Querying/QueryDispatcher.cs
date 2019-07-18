using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Querying
{
    public class QueryDispatcher : IQueryDispatcher
    {
        protected IQueryExecutorFactory ExecutorFactory { get; }

        public QueryDispatcher(IQueryExecutorFactory executorFactory)
        {
            ExecutorFactory = executorFactory;
        }

        public TResult Dispatch<TResult>(IQuery<TResult> query)
        {
            return Executor(query).Execute(query);
        }

        public Task<TResult> DispatchAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Executor(query).ExecuteAsync(query, cancellationToken);
        }

        private IQueryExecutor<TResult> Executor<TResult>(IQuery<TResult> query)
        {
            var queryType = query.GetType();
            var resultType = typeof(TResult);

            return ExecutorFactory.Get<TResult>(typeof(QueryExecutor<,>).MakeGenericType(queryType, resultType));
        }
    }
}