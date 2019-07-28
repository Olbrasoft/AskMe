using System;
using Microsoft.Extensions.DependencyInjection;

namespace Olbrasoft.Querying.DependencyInjection.Microsoft
{
    public class QueryExecutorFactoryWithServiceScopeFactory : BaseQueryExecutorFactory
    {
        private readonly IServiceScopeFactory _factory;

        private IServiceProvider _provider;

        protected IServiceProvider Provider => _provider ?? (_provider = _factory.CreateScope().ServiceProvider);

        public QueryExecutorFactoryWithServiceScopeFactory(IServiceScopeFactory factory)
        {
            _factory = factory;
        }

        public override IQueryExecutor<TResult> CreateExecutor<TResult>(Type executorType) => (IQueryExecutor<TResult>)Provider.GetService(executorType);
    }
}