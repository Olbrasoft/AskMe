using System.Data;
using Olbrasoft.Data;
using Olbrasoft.Mapping;

namespace Olbrasoft.Querying.Mapping.Data
{
    public abstract class QueryHandlerWithMapperAndDbConnectionFactory<TQuery, TResult> : QueryHandlerWithMapper<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        private readonly IDbConnectionFactory _factory;

        protected QueryHandlerWithMapperAndDbConnectionFactory(IMapper mapper, IDbConnectionFactory factory) : base(mapper)
        {
            _factory = factory;
        }

        protected IDbConnection GetConnection()
        {
            return _factory.OpenConnection();
        }
    }
}