using System;
using Moq;
using Xunit;

namespace Olbrasoft.Commanding.DependencyInjection.Microsoft
{
    public class CommandFactoryWithServiceProviderTest
    {
        private readonly Mock<IServiceProvider> _providerMock = new Mock<IServiceProvider>();

        [Fact]
        public void Instance_Inherits_From_BaseQueryFactory()
        {
            var type = typeof(BaseCommandFactory);

            var factory = QueryFactoryWithServiceProvider();

            Assert.IsAssignableFrom(type, factory);
        }

        private CommandFactoryWithServiceProvider QueryFactoryWithServiceProvider()
        {
            var factory = new CommandFactoryWithServiceProvider(_providerMock.Object);
            return factory;
        }

        [Fact]
        public void Create_Return_Provider_GetService()
        {
            var factory = QueryFactoryWithServiceProvider();

            factory.Create<Command>();

            _providerMock.Verify(p => p.GetService(typeof(Command)), Times.Once);
        }
    }
}