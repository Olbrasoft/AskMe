using System;
using Microsoft.Extensions.DependencyInjection;

namespace Olbrasoft.Commanding.DependencyInjection.Microsoft
{
    public class CommandFactoryWithServiceScopeFactory : BaseCommandFactory
    {
        private readonly IServiceScopeFactory _factory;

        private IServiceProvider _provider;

        protected IServiceProvider Provider => _provider ?? (_provider = _factory.CreateScope().ServiceProvider);

        public CommandFactoryWithServiceScopeFactory(IServiceScopeFactory factory)
        {
            _factory = factory;
        }

        public override T CreateCommand<T>()
        {
            return Provider.GetService<T>();
        }
    }
}