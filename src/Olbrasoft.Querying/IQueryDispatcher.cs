using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Querying
{
    public interface IQueryDispatcher
    {
        /// <summary>
        /// Runs the query queryHandler registered for the given command type.
        /// If there is no queryHandler for a given query type or there is more than one, this method will throw.
        /// </summary>
        /// <typeparam name="TResult">Type of the query</typeparam>
        /// <param name="query">Instance of the query</param>
        /// <returns>Result of the query queryHandler</returns>
        TResult Dispatch<TResult>(IQuery<TResult> query);

        /// <summary>
        /// Runs the query queryHandler registered for the given command type.
        /// If there is no queryHandler for a given query type or there is more than one, this method will throw.
        /// </summary>
        /// <typeparam name="TResult">Type of the query</typeparam>
        /// <param name="query">Instance of the query</param>
        /// <param name="token">Optional cancellation token</param>
        /// <returns>Task that resolves to a result of the query queryHandler</returns>
        Task<TResult> DispatchAsync<TResult>(IQuery<TResult> query, CancellationToken token);
    }
}