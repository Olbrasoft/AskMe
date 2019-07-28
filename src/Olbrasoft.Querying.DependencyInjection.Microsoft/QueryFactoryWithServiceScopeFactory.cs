using System;
using Microsoft.Extensions.DependencyInjection;

namespace Olbrasoft.Querying.DependencyInjection.Microsoft
{
    public class QueryFactoryWithServiceScopeFactory : BaseQueryFactory
    {
        private readonly IServiceScopeFactory _factory;

        private IServiceProvider _provider;

        protected IServiceProvider Provider => _provider ?? (_provider = _factory.CreateScope().ServiceProvider);

        public QueryFactoryWithServiceScopeFactory(IServiceScopeFactory factory)
        {
            _factory = factory;
        }

        public override T CreateQuery<T>() => Provider.GetService<T>();
    }
}