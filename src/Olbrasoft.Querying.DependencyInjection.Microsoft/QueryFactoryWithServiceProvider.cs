using System;
using Microsoft.Extensions.DependencyInjection;

namespace Olbrasoft.Querying.DependencyInjection.Microsoft
{
    public class QueryFactoryWithServiceProvider : BaseQueryFactory
    {
        private readonly IServiceProvider _provider;

        public QueryFactoryWithServiceProvider(IServiceProvider provider)
        {
            _provider = provider;
        }

        public override T Create<T>()
        {
            
            T result;

            using (var scope = _provider.CreateScope())
            {
                result = (T)scope.ServiceProvider.GetService(typeof(T));
            }

            return result;
           
        }
    }
}