using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;

namespace Olbrasoft.Commanding.Castle
{
    public static class ContainerExtensions
    {
        public static void AddCommanding(this IWindsorContainer container)
        {
            container.Register(Component.For<ICommandFactory>().AsFactory());

            container.Register(Component.For(typeof(CommandExecutor<>)).ImplementedBy(typeof(CommandExecutor<>))
                .LifestyleCustom<MsScopedLifestyleManager>());

            container.Register(Component.For<ICommandExecutorFactory>().ImplementedBy<CommandExecutorFactory>().LifestyleSingleton());

            container.Register(Component.For<ICommandDispatcher>().ImplementedBy<CommandDispatcher>().LifestyleSingleton());
        }
    }
}