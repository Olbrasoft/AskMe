using System;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace Olbrasoft.Querying.DependencyInjection.Microsoft
{
    public class QueryExecutorFactoryWithServiceProviderTest
    {
        private readonly Mock<IServiceScopeFactory> _factoryMock = new Mock<IServiceScopeFactory>();

        [Fact]
        public void Instance_Inherits_From_BaseQueryExecutorFactory()
        {
            var type = typeof(BaseQueryExecutorFactory);

            var factory = QueryExecutorFactoryWithServiceProvider();

            Assert.IsAssignableFrom(type, factory);
        }

        private QueryExecutorFactoryWithServiceScopeFactory QueryExecutorFactoryWithServiceProvider()
        {
            var scopeMock = new Mock<IServiceScope>();

            scopeMock.Setup(p => p.ServiceProvider).Returns(new Mock<IServiceProvider>().Object);

            _factoryMock.Setup(p => p.CreateScope()).Returns(scopeMock.Object);

            var factory = new QueryExecutorFactoryWithServiceScopeFactory(_factoryMock.Object);
            return factory;
        }

        [Fact]
        public void Get_Call_Provider_GetService()
        {
            var factory = QueryExecutorFactoryWithServiceProvider();

            var executorType = typeof(QueryExecutor<Query<bool>, bool>);

            factory.CreateExecutor<bool>(executorType);

            _factoryMock.Verify(p => p.CreateScope(), Times.Once);
        }
    }
}