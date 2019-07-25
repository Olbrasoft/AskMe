using System;

namespace Olbrasoft.Querying.DependencyInjection.Microsoft
{
    public class QueryFactoryWithServiceProvider : BaseQueryFactory
    {
        private readonly IServiceProvider _provider;

        public QueryFactoryWithServiceProvider(IServiceProvider provider)
        {
            this._provider = provider;
        }

        public override T Create<T>()
        {
            return (T)_provider.GetService(typeof(T));
        }
    }
}