using System;
using Castle.Windsor;

namespace Olbrasoft.Commanding.DependencyInjection.Castle
{
    public class CommandExecutorFactoryWithWindsorContainer : BaseCommandExecutorFactory
    {
        private readonly IWindsorContainer _container;

        public CommandExecutorFactoryWithWindsorContainer(IWindsorContainer container)
        {
            _container = container;
        }

        public override ICommandExecutor Get(Type executorType)
        {
            return (ICommandExecutor)_container.Resolve(executorType);
        }
    }
}