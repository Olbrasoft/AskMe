using System.Linq;
using System.Reflection;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using Olbrasoft.Extensions;

namespace Olbrasoft.Commanding.Castle
{
    public static class ContainerExtensions
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

            container.Register(Component.For<ICommandExecutorFactory>().ImplementedBy<CommandExecutorFactory>()
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

            var classes = assemblies
                .Where(a => !a.IsDynamic && a.GetName().Name != typeof(Command<>).Assembly.GetName().Name)
                .Distinct()
                .SelectMany(a => a.DefinedTypes).Where(c => c.IsClass && !c.IsAbstract).ToArray();

            var commandGenericInterface = new[] {typeof(ICommand<>)};

            var commandTypes = commandGenericInterface.SelectMany(openType => classes
                .Where(t => t.AsType().ImplementsGenericInterface(openType) ||
                            t.ImplementedInterfaces.Any(p => p.Name == nameof(ICommand))));

            foreach (var queryType in commandTypes)
            {
                container.Register(Component.For(queryType));
            }

            var handlerAllowed = new[] {typeof(ICommandHandler<>)};

            var commandHandlerTypes = handlerAllowed.SelectMany(openType => classes
                .Where(t => t.AsType().ImplementsGenericInterface(openType)));

            foreach (var typeInfo in commandHandlerTypes)
            {
                container.Register(Component.For(typeInfo.GetInterfaces().First()).ImplementedBy(typeInfo)
                    .LifestyleCustom<MsScopedLifestyleManager>());
            }
        }
    }
}