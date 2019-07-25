using System;

namespace Olbrasoft.Commanding.DependencyInjection.Microsoft
{
    public class CommandFactoryWithServiceProvider : BaseCommandFactory
    {
        private readonly IServiceProvider _provider;

        public CommandFactoryWithServiceProvider(IServiceProvider provider)
        {
            _provider = provider;
        }

        public override T Create<T>()
        {
            return (T)_provider.GetService(typeof(T));
        }
    }
}