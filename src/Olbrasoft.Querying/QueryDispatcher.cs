using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Querying
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

        public Task<TResult> DispatchAsync<TResult>(IQuery<TResult> query, CancellationToken token = default)
        {
            var e = Executor(query);

            return e.ExecuteAsync(query, token);
        }

        private IQueryExecutor<TResult> Executor<TResult>(IQuery<TResult> query)
        {
            var queryType = query.GetType();
            var resultType = typeof(TResult);


            var a = ExecutorFactory.Get<TResult>(typeof(QueryExecutor<,>).MakeGenericType(queryType, resultType));

            return a;
        }
    }
}