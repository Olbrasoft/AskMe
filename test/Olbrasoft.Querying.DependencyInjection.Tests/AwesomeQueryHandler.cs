using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Querying.DependencyInjection
{
    public class AwesomeQueryHandler:QueryHandler<AwesomeQuery,bool>
    {
        public override Task<bool> HandleAsync(AwesomeQuery query, CancellationToken token) => throw new NotImplementedException();
    }
}
