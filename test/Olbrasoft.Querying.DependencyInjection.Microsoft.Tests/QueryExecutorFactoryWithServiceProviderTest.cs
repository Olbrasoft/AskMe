using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace Olbrasoft.Querying.DependencyInjection.Microsoft
{
    public class QueryExecutorFactoryWithServiceProviderTest
    {
        //private readonly Mock<IServiceProvider> _providerMock = new Mock<IServiceProvider>();
        private readonly Mock<IServiceProvider> _providerMock = new Mock<IServiceProvider>();


        [Fact]
        public void Instance_Inherits_From_BaseQueryExecutorFactory()
        {
            var type = typeof(BaseQueryExecutorFactory);

            var factory = QueryExecutorFactoryWithServiceProvider();

            Assert.IsAssignableFrom(type, factory);
        }

        private QueryExecutorFactoryWithServiceProvider QueryExecutorFactoryWithServiceProvider()
        {
            var scopeMock = new Mock<IServiceScope>();

            scopeMock.Setup(p => p.ServiceProvider).Returns(new Mock<IServiceProvider>().Object);

            
            
            var factory = new QueryExecutorFactoryWithServiceProvider(_providerMock.Object);
            return factory;
        }

        [Fact]
        public void Get_Call_Provider_GetService()
        {
            var factory = QueryExecutorFactoryWithServiceProvider();

            var executorType = typeof(QueryExecutor<Query<bool>, bool>);

         //   factory.Get<bool>(executorType);

           // _providerMock.Verify(p=>p.CreateScope(), Times.Once);
        }
    }

   
}