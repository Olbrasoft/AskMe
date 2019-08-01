using System;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Mapping;

namespace Olbrasoft.Querying.Mapping
{
    public class AwesomeQueryHandlerWithMapper : QueryHandlerWithMapper<Query<bool>, bool>
    {
        public override Task<bool> HandleAsync(Query<bool> query, CancellationToken token) => throw new NotImplementedException();

        public AwesomeQueryHandlerWithMapper(IMapper mapper) : base(mapper)
        {
        }

        public void CallMapTo()
        {
            MapTo<bool>(true);
        }
        
    }
}