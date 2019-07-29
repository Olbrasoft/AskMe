using System;
using Microsoft.Extensions.DependencyInjection;

namespace Olbrasoft.Commanding.DependencyInjection.Microsoft
{
    public class CommandExecutorFactoryWithServiceScopeFactory : BaseCommandExecutorFactory
    {
        private readonly IServiceScopeFactory _factory;

        private IServiceProvider _provider;

        protected IServiceProvider Provider => _provider ?? (_provider = _factory.CreateScope().ServiceProvider);

        public CommandExecutorFactoryWithServiceScopeFactory(IServiceScopeFactory factory)
        {
            _factory = factory;
        }

        public override ICommandExecutor CreateExecutor(Type executor)
        {
            return (ICommandExecutor)Provider.GetService(executor);
        }
    }
}