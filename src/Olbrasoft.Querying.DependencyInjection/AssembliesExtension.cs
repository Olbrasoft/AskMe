using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Olbrasoft.Extensions;

namespace Olbrasoft.Querying.DependencyInjection
{
    public static class AssembliesExtension
    {
        private static IEnumerable<TypeInfo> AllTypes(IEnumerable<Assembly> assemblies)
        {
            return assemblies.Where(a => !a.IsDynamic && a.GetName().Name != typeof(Query<>).Assembly.GetName().Name).Distinct()
                .SelectMany(a => a.DefinedTypes).Where(c => c.IsClass && !c.IsAbstract);
        }

        public static IEnumerable<TypeInfo> GetQueryTypes(this IEnumerable<Assembly> assemblies)
        {
            var queryGenericInterface = new[] { typeof(IQuery<>) };

            return queryGenericInterface.SelectMany(openType => AllTypes(assemblies)
                 .Where(t => t.AsType().ImplementsGenericInterface(openType) || t.ImplementedInterfaces.Any(p => p.Name == nameof(IQuery))));
        }

        public static IEnumerable<TypeInfo> GetQueryHandlerTypes(this IEnumerable<Assembly> assemblies)
        {
            var handlerAllowed = new[] { typeof(IQueryHandler<,>) };

            return handlerAllowed.SelectMany(openType => AllTypes(assemblies)
                 .Where(t => t.AsType().ImplementsGenericInterface(openType)));
        }
    }
}