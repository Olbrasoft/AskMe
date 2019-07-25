using System;

namespace Olbrasoft.Commanding.DependencyInjection.Microsoft
{
    public class CommandExecutorFactoryWithServiceProvider:BaseCommandExecutorFactory
    {
        private readonly IServiceProvider _provider;

        public CommandExecutorFactoryWithServiceProvider(IServiceProvider provider)
        {
            _provider = provider;
        }


        public override ICommandExecutor Get(Type executorType)
        {
            return (ICommandExecutor) _provider.GetService(executorType);
        }
    }
}