using System;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace Olbrasoft.Querying.DependencyInjection.Microsoft.Tests
{
    public class QueryFactoryWithHttpContextAccessorTest
    {
      
        private readonly Mock<IHttpContextAccessor> _accessorMock= new Mock<IHttpContextAccessor>();

        [Fact]
        public void Instance_Inherits_From_BaseQueryFactory()
        {
            var type = typeof(BaseQueryFactory);

            var factory = QueryFactoryWithServiceProvider();

            Assert.IsAssignableFrom(type, factory);
        }

        private QueryFactoryWithHttpContextAccessor QueryFactoryWithServiceProvider()
        {
            
            var httpMock = new Mock<HttpContext>();
            httpMock.Setup(p => p.RequestServices).Returns(new Mock<IServiceProvider>().Object);

            _accessorMock.Setup(p => p.HttpContext).Returns(httpMock.Object);
            
            var factory = new QueryFactoryWithHttpContextAccessor(_accessorMock.Object);
            return factory;
        }

        [Fact]
        public void Create_Return_Provider_GetService()
        {
            var factory = QueryFactoryWithServiceProvider();

            factory.Create<Query<bool>>();

            _accessorMock.Verify(p=>p.HttpContext, Times.Once);
        }

    }
}