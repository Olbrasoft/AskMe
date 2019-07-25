using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Olbrasoft.Querying.DependencyInjection.Microsoft
{
    public static class ServicesExtension
    {
        public static void AddQuering(this IServiceCollection services)
        {
            services.AddScoped<IQueryFactory, QueryFactoryWithServiceProvider>();

            services.AddScoped(typeof(QueryExecutor<,>), typeof(QueryExecutor<,>));

            services.AddScoped<IQueryExecutorFactory, QueryExecutorFactoryWithServiceProvider>();

            services.AddScoped<IQueryDispatcher, QueryDispatcher>();
        }

        public static void AddQuering(this IServiceCollection services, params Assembly[] assemblies)
        {
            AddQuering(services);

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