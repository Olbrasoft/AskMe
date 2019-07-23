using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Querying
{
    public class AwesomeQueryHandler : QueryHandler<Query<bool>, int[], bool>
    {
        public override Task<bool> HandleAsync(Query<bool> query, CancellationToken token)
        {
            return Task.FromResult(true);
        }

        public new int[] Source => base.Source;

        protected override int[] GetSource()
        {
            return new[] { 1976 };
        }
    }
}