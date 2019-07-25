using System;
using System.Linq;
using System.Reflection;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;

namespace Olbrasoft.Querying.DependencyInjection.Castle
{
    public static class ContainerExtensions
    {
        public static void AddQuering(this IWindsorContainer container)
        {
            if (!container.Kernel.HasComponent(typeof(ITypedFactoryComponentSelector)))
            {
                container.AddFacility<TypedFactoryFacility>();
            }

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

            foreach (var queryType in assemblies.GetQueryTypes())
            {
                container.Register(Component.For(queryType));
            }

            foreach (var typeInfo in assemblies.GetQueryHandlerTypes())
            {
                container.Register(Component.For(typeInfo.GetInterfaces().First()).ImplementedBy(typeInfo).LifestyleCustom<MsScopedLifestyleManager>());
            }
        }
    }
}