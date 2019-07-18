using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Querying
{
    public interface IQueryExecutor<TResult>
    {
        TResult Execute(IQuery<TResult> query);

        Task<TResult> ExecuteAsync(IQuery<TResult> query, CancellationToken cancellationToken);
    }
}