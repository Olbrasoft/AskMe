using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Data.Querying;

namespace Olbrasoft.Data.Unit.Tests.Querying
{
    internal class AwesomeQueryHandler : Handler<AwesomeQuery, object>
    {
        public override Task<object> HandleAsync(AwesomeQuery query, CancellationToken token)
        {
            return Task<object>.Factory.StartNew(() => new object(), token);
        }
    }

}