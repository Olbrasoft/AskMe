using System;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace Olbrasoft.Querying.DependencyInjection.Microsoft
{
    public class QueryExecutorFactoryWithHttpContextAccessorTest
    {
        //private readonly Mock<IServiceProvider> _providerMock = new Mock<IServiceProvider>();
        private readonly Mock<IHttpContextAccessor> _accessorMock = new Mock<IHttpContextAccessor>();

        [Fact]
        public void Instance_Inherits_From_BaseQueryExecutorFactory()
        {
            var type = typeof(BaseQueryExecutorFactory);

            var factory = QueryExecutorFactoryWithServiceProvider();

            Assert.IsAssignableFrom(type, factory);
        }

        private QueryExecutorFactoryWithHttpContextAccessor QueryExecutorFactoryWithServiceProvider()
        {
            var httpMOck = new Mock<HttpContext>();

            httpMOck.Setup(p => p.RequestServices).Returns(new Mock<IServiceProvider>().Object);
            
            _accessorMock.Setup(p => p.HttpContext).Returns(httpMOck.Object);

            var factory = new QueryExecutorFactoryWithHttpContextAccessor(_accessorMock.Object);
            return factory;
        }

        [Fact]
        public void Get_Call_Provider_GetService()
        {
            var factory = QueryExecutorFactoryWithServiceProvider();

            var executorType = typeof(QueryExecutor<Query<bool>, bool>);

            factory.Get<bool>(executorType);

            _accessorMock.Verify(p=>p.HttpContext, Times.Once);
        }
    }

   
}