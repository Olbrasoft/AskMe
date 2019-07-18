using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Unit.Tests
{
    public abstract class LocalizedQuery<TResult>:ILocalizedQuery<TResult>
    {
        public int LanguageId { get; set; }
        public abstract TResult Execute();
        public Task<TResult> ExecuteAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}