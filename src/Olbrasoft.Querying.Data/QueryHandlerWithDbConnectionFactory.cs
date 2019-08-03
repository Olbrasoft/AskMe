using Olbrasoft.Data;
using System.Data;

namespace Olbrasoft.Querying.Data
{
    public abstract class QueryHandlerWithDbConnectionFactory<TQuery, TResult> : QueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        private readonly IDbConnectionFactory _factory;

        protected QueryHandlerWithDbConnectionFactory(IDbConnectionFactory factory)
        {
            _factory = factory;
        }

        protected IDbConnection GetConnection()
        {
            return _factory.OpenConnection();
        }
    }
}