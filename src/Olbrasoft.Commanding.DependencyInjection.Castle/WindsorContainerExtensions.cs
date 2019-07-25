using System.Linq;
using System.Reflection;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;

namespace Olbrasoft.Commanding.DependencyInjection.Castle
{
    public static class WindsorContainerExtensions
    {
        public static void AddCommanding(this IWindsorContainer container)
        {
            if (!container.Kernel.HasComponent(typeof(ITypedFactoryComponentSelector)))
            {
                container.AddFacility<TypedFactoryFacility>();
            }

            container.Register(Component.For<ICommandFactory>().AsFactory());

            container.Register(Component.For(typeof(CommandExecutor<>)).ImplementedBy(typeof(CommandExecutor<>))
                .LifestyleCustom<MsScopedLifestyleManager>());

            container.Register(Component.For<ICommandExecutorFactory>().ImplementedBy<CommandExecutorFactoryWithWindsorContainer>()
                .LifestyleSingleton());

            container.Register(Component.For<ICommandDispatcher>().ImplementedBy<CommandDispatcher>()
                .LifestyleSingleton());
        }

        /// <summary>
        /// Registration Commanding components
        /// </summary>
        /// <param name="container"></param>
        /// <param name="assemblies">which contain commands and command handlers</param>
        public static void AddCommanding(this IWindsorContainer container, params Assembly[] assemblies)
        {
            AddCommanding(container);

            foreach (var queryType in assemblies.GetCommandTypes())
            {
                container.Register(Component.For(queryType));
            }

            foreach (var typeInfo in assemblies.GetCommandHandlerTypes())
            {
                container.Register(Component.For(typeInfo.GetInterfaces().First()).ImplementedBy(typeInfo)
                    .LifestyleCustom<MsScopedLifestyleManager>());
            }
        }
    }
}