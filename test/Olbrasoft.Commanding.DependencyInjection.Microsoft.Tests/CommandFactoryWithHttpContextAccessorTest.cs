using System;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace Olbrasoft.Commanding.DependencyInjection.Microsoft
{
    public class CommandFactoryWithHttpContextAccessorTest
    {
        private readonly Mock<IHttpContextAccessor> _accessorMock = new Mock<IHttpContextAccessor>();

        [Fact]
        public void Instance_Inherits_From_BaseQueryFactory()
        {
            var type = typeof(BaseCommandFactory);

            var factory = QueryFactoryWithServiceProvider();

            Assert.IsAssignableFrom(type, factory);
        }

        private CommandFactoryWithHttpContextAccessor QueryFactoryWithServiceProvider()
        {
            
            var contextMock = new Mock<HttpContext>();
            contextMock.Setup(p => p.RequestServices).Returns(new Mock<IServiceProvider>().Object);

            _accessorMock.Setup(p => p.HttpContext).Returns(contextMock.Object);

            var factory = new CommandFactoryWithHttpContextAccessor(_accessorMock.Object);
            return factory;
        }

        [Fact]
        public void Create_Return_Provider_GetService()
        {
            var factory = QueryFactoryWithServiceProvider();

            factory.Create<Command>();

            _accessorMock.Verify(p=>p.HttpContext, Times.Once);

        }
    }
}