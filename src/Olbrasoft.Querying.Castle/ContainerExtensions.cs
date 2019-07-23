using System;
using System.Linq;
using System.Reflection;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;

namespace Olbrasoft.Querying.Castle
{
    public static class ContainerExtensions
    {
        public static void AddQuering(this IWindsorContainer container)
        {
            container.Register(Component.For<IQueryFactory>().AsFactory());

            container.Register(Component.For(typeof(QueryExecutor<,>)).ImplementedBy(typeof(QueryExecutor<,>))
                .LifestyleCustom<MsScopedLifestyleManager>());

            container.Register(Component.For<IQueryExecutorFactory>().ImplementedBy<QueryExecutorFactory>().LifestyleSingleton());

            container.Register(Component.For<IQueryDispatcher>().ImplementedBy<QueryDispatcher>().LifestyleSingleton());
        }

        /// <summary>
        /// Registration Quering components
        /// </summary>
        /// <param name="container"></param>
        /// <param name="assemblies">which contain queries and query handlers</param>
        public static void AddQuering(this IWindsorContainer container, params Assembly[] assemblies)
        {
            AddQuering(container);
            
            var classes = assemblies
                 .Where(a => !a.IsDynamic && a.GetName().Name != nameof(Olbrasoft.Querying))
                 .Distinct()
                 .SelectMany(a => a.DefinedTypes).Where(c => c.IsClass && !c.IsAbstract)
                 .ToArray();

            var queryGenericInterface = new[]
            {
                typeof(IQuery<>)
            };

            var queryTypes = queryGenericInterface.SelectMany(openType => classes
                .Where(t => t.AsType().ImplementsGenericInterface(openType) ||
                            t.ImplementedInterfaces.Any(p => p.Name == nameof(IQuery))));

            foreach (var queryType in queryTypes)
            {
                container.Register(Component.For(queryType));
            }

            var handlerTypeGenericInterfaces = new[] { typeof(IQueryHandler<,>)};

            var queryHandlerTypes = handlerTypeGenericInterfaces.SelectMany(openType => classes
                .Where(t => t.AsType().ImplementsGenericInterface(openType)));

            foreach (var queryHandlerType in queryHandlerTypes)
            {
                container.Register(Component.For(queryHandlerType.GetInterfaces().First()).ImplementedBy(queryHandlerType).LifestyleCustom<MsScopedLifestyleManager>());
            }
        }

        private static bool ImplementsGenericInterface(this Type type, Type interfaceType)
            => type.IsGenericType(interfaceType) || type.GetTypeInfo().ImplementedInterfaces.Any(@interface => @interface.IsGenericType(interfaceType));

        private static bool IsGenericType(this Type type, Type genericType)
            => type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == genericType;
    }
}