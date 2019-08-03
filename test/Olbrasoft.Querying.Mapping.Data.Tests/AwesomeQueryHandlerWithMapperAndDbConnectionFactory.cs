using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Data;
using Olbrasoft.Mapping;

namespace Olbrasoft.Querying.Mapping.Data
{
    public class AwesomeQueryHandlerWithMapperAndDbConnectionFactory: QueryHandlerWithMapperAndDbConnectionFactory<Query<bool>, bool>
    {
        public void CallGetConnection()
        {
            GetConnection();
        }

        public AwesomeQueryHandlerWithMapperAndDbConnectionFactory(IMapper mapper, IDbConnectionFactory factory) : base(mapper, factory)
        {
        }

        public override Task<bool> HandleAsync(Query<bool> query, CancellationToken token) => throw new System.NotImplementedException();
    }
}