using System;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace Olbrasoft.Commanding.DependencyInjection.Microsoft
{
    public class CommandFactoryWithServiceScopeFactoryTest
    {
        private readonly Mock<IServiceScopeFactory> _factoryMock = new Mock<IServiceScopeFactory>();

        [Fact]
        public void Instance_Inherits_From_BaseQueryFactory()
        {
            var type = typeof(BaseCommandFactory);

            var factory = QueryFactoryWithServiceProvider();

            Assert.IsAssignableFrom(type, factory);
        }

        private CommandFactoryWithServiceScopeFactory QueryFactoryWithServiceProvider()
        {
            var scopeMock = new Mock<IServiceScope>();
            var providerMock = new Mock<IServiceProvider>();

            scopeMock.Setup(scope => scope.ServiceProvider).Returns(providerMock.Object);

            _factoryMock.Setup(p => p.CreateScope()).Returns(scopeMock.Object);

            var factory = new CommandFactoryWithServiceScopeFactory(_factoryMock.Object);
            return factory;
        }

        [Fact]
        public void Create_Return_Provider_GetService()
        {
            var factory = QueryFactoryWithServiceProvider();

            factory.CreateCommand<Command>();

           _factoryMock.Verify(f=>f.CreateScope(),Times.Once);
        }
    }
}