using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using Olbrasoft.Extensions;

namespace Olbrasoft.Commanding.DependencyInjection
{
    public static class AssembliesExtension
    {
        private static IEnumerable<TypeInfo> AllTypes(IEnumerable<Assembly> assemblies)
        {
            return assemblies.Where(a => !a.IsDynamic && a.GetName().Name != typeof(Command<>).Assembly.GetName().Name).Distinct()
                .SelectMany(a => a.DefinedTypes).Where(c => c.IsClass && !c.IsAbstract);
        }


        public static IEnumerable<TypeInfo> GetCommandTypes(this IEnumerable<Assembly> assemblies)
        {
            var queryGenericInterface = new[] { typeof(ICommand<>) };

            return queryGenericInterface.SelectMany(openType => AllTypes(assemblies)
                .Where(t => t.AsType().ImplementsGenericInterface(openType) || t.ImplementedInterfaces.Any(p => p.Name == nameof(ICommand))));
        }

        public static IEnumerable<TypeInfo> GetCommandHandlerTypes(this IEnumerable<Assembly> assemblies)
        {
            var handlerAllowed = new[] { typeof(ICommandHandler<>) };

            return handlerAllowed.SelectMany(openType => AllTypes(assemblies)
                .Where(t => t.AsType().ImplementsGenericInterface(openType)));
        }
    }
}