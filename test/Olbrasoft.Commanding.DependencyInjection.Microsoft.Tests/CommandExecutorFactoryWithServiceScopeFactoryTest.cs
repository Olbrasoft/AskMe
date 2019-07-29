using System;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace Olbrasoft.Commanding.DependencyInjection.Microsoft
{
    public class CommandExecutorFactoryWithServiceScopeFactoryTest
    {
        private readonly Mock<IServiceScopeFactory> _factoryMock = new Mock<IServiceScopeFactory>();

        [Fact]
        public void Instance_Inherits_From_BaseQueryExecutorFactory()
        {
            var type = typeof(BaseCommandExecutorFactory);

            var factory = QueryExecutorFactoryWithServiceProvider();

            Assert.IsAssignableFrom(type, factory);
        }

        private CommandExecutorFactoryWithServiceScopeFactory QueryExecutorFactoryWithServiceProvider()
        {
            var scopeMock = new Mock<IServiceScope>();
            var providerMock = new Mock<IServiceProvider>();
            scopeMock.Setup(s => s.ServiceProvider).Returns(providerMock.Object);

            _factoryMock.Setup(f => f.CreateScope()).Returns(scopeMock.Object);

            var factory = new CommandExecutorFactoryWithServiceScopeFactory(_factoryMock.Object);
            return factory;
        }

        [Fact]
        public void Get_Call_Provider_GetService()
        {
            var factory = QueryExecutorFactoryWithServiceProvider();

            var executorType = typeof(CommandExecutor<Command>);

            factory.CreateExecutor(executorType);

            _factoryMock.Verify(f => f.CreateScope(), Times.Once);
        }
    }
}