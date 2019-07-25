using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Olbrasoft.Commanding.DependencyInjection.Microsoft
{
    public class CommandExecutorFactoryWithServiceProviderTest
    {
        private readonly Mock<IServiceProvider> _providerMock = new Mock<IServiceProvider>();

        [Fact]
        public void Instance_Inherits_From_BaseQueryExecutorFactory()
        {
            var type = typeof(BaseCommandExecutorFactory);

            var factory = QueryExecutorFactoryWithServiceProvider();

            Assert.IsAssignableFrom(type, factory);
        }

        private CommandExecutorFactoryWithServiceProvider QueryExecutorFactoryWithServiceProvider()
        {
            var factory = new CommandExecutorFactoryWithServiceProvider(_providerMock.Object);
            return factory;
        }

        [Fact]
        public void Get_Call_Provider_GetService()
        {
            var factory = QueryExecutorFactoryWithServiceProvider();

            var executorType = typeof(CommandExecutor<Command>);

            factory.Get(executorType);

            _providerMock.Verify(p => p.GetService(executorType), Times.Once);
        }
    }
}
