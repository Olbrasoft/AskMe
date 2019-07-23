using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Querying
{
    public class Query<TResult> : IQuery<TResult>
    {
        protected IQueryDispatcher Dispatcher { get; }

        public Query(IQueryDispatcher dispatcher)
        {
            Dispatcher = dispatcher;
        }

        public TResult Execute()
        {
            return Dispatcher.Dispatch(this);
        }

        public Task<TResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            return Dispatcher.DispatchAsync(this, cancellationToken);
        }
    }
}