using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Olbrasoft.Querying.DependencyInjection.Microsoft
{
    public static class ServicesExtension
    {
        public static void AddQuerying(this IServiceCollection services)
        {
            services.AddSingleton<IQueryFactory, QueryFactoryWithServiceScopeFactory>();

            services.AddScoped(typeof(QueryExecutor<,>), typeof(QueryExecutor<,>));

            services.AddSingleton<IQueryExecutorFactory, QueryExecutorFactoryWithServiceScopeFactory>();

            services.AddSingleton<IQueryDispatcher, QueryDispatcher>();
        }

        public static void AddQuerying(this IServiceCollection services, params Assembly[] assemblies)
        {
            AddQuerying(services);

            foreach (var queryType in assemblies.GetQueryTypes())
            {
                services.AddScoped(queryType);
            }

            foreach (var typeInfo in assemblies.GetQueryHandlerTypes())
            {
                services.AddScoped(typeInfo.GetInterfaces().First(), typeInfo);
            }
        }
    }
}