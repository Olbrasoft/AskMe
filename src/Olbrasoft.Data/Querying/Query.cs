using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Querying
{
    public abstract class Query<TResult> : IQuery<TResult>
    {
        protected IQueryDispatcher Dispatcher { get; }

        protected Query(IQueryDispatcher dispatcher)
        {
            Dispatcher = dispatcher;
        }

        public TResult Execute()
        {
            return Dispatcher.Dispatch(this);
        }

        public Task<TResult> ExecuteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Dispatcher.DispatchAsync(this, cancellationToken);
        }
    }
}