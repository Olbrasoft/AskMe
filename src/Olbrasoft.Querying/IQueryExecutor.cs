using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Querying
{
    public interface IQueryExecutor<TResult>
    {
        TResult Execute(IQuery<TResult> query);

        Task<TResult> ExecuteAsync(IQuery<TResult> query, CancellationToken token);
    }
}