using System;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace Olbrasoft.Querying.DependencyInjection.Microsoft
{
    public class QueryFactoryWithServiceScopeFactoryTest
    {
        private readonly Mock<IServiceScopeFactory> _factoryMock = new Mock<IServiceScopeFactory>();

        [Fact]
        public void Instance_Inherits_From_BaseQueryFactory()
        {
            var type = typeof(BaseQueryFactory);

            var factory = QueryFactoryWithServiceProvider();

            Assert.IsAssignableFrom(type, factory);
        }

        private QueryFactoryWithServiceScopeFactory QueryFactoryWithServiceProvider()
        {
            var providerMock = new Mock<IServiceProvider>();

            var scopeMock = new Mock<IServiceScope>();

            scopeMock.Setup(p => p.ServiceProvider).Returns(providerMock.Object);

            _factoryMock.Setup(p => p.CreateScope()).Returns(scopeMock.Object);

            var factory = new QueryFactoryWithServiceScopeFactory(_factoryMock.Object);
            return factory;
        }

        [Fact]
        public void Create_Return_Provider_GetService()
        {
            var factory = QueryFactoryWithServiceProvider();

            factory.CreateQuery<Query<bool>>();

            _factoryMock.Verify(p => p.CreateScope(), Times.Once);
        }
    }
}