using System;
using Moq;
using Xunit;

namespace Olbrasoft.Querying.DependencyInjection.Microsoft.Tests
{
    public class QueryFactoryWithServiceProviderTest
    {
        private readonly Mock<IServiceProvider> _providerMock = new Mock<IServiceProvider>();

        [Fact]
        public void Instance_Inherits_From_BaseQueryFactory()
        {
            var type = typeof(BaseQueryFactory);

            var factory = QueryFactoryWithServiceProvider();

            Assert.IsAssignableFrom(type, factory);
        }

        private QueryFactoryWithServiceProvider QueryFactoryWithServiceProvider()
        {
            var factory = new QueryFactoryWithServiceProvider(_providerMock.Object);
            return factory;
        }

        [Fact]
        public void Create_Return_Provider_GetService()
        {
            var factory = QueryFactoryWithServiceProvider();

            factory.Create<Query<bool>>();

            _providerMock.Verify(p=>p.GetService(typeof(Query<bool>)), Times.Once);
        }

    }
}