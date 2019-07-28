using System;
using Microsoft.Extensions.DependencyInjection;

namespace Olbrasoft.Querying.DependencyInjection.Microsoft
{
    public class QueryExecutorFactoryWithServiceProvider : BaseQueryExecutorFactory
    {
        private readonly IServiceProvider _provider;

        public QueryExecutorFactoryWithServiceProvider(IServiceProvider provider)
        {
            _provider = provider;
        }

        public override IQueryExecutor<TResult> Get<TResult>(Type executorType)
        {
            return (IQueryExecutor<TResult>)_provider.CreateScope().ServiceProvider.GetService(executorType);
        }
    }
}