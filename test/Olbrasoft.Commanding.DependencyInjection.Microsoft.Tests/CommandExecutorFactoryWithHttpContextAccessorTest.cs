using System;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace Olbrasoft.Commanding.DependencyInjection.Microsoft
{
    public class CommandExecutorFactoryWithHttpContextAccessorTest
    {
        private readonly Mock<IHttpContextAccessor> _accessorMock = new Mock<IHttpContextAccessor>();

        [Fact]
        public void Instance_Inherits_From_BaseQueryExecutorFactory()
        {
            var type = typeof(BaseCommandExecutorFactory);

            var factory = QueryExecutorFactoryWithServiceProvider();

            Assert.IsAssignableFrom(type, factory);
        }

        private CommandExecutorFactoryWithHttpContextAccessor QueryExecutorFactoryWithServiceProvider()
        {
            var contextMock = new Mock<HttpContext>();

            contextMock.Setup(p => p.RequestServices).Returns(new Mock<IServiceProvider>().Object);

            _accessorMock.Setup(p => p.HttpContext).Returns(contextMock.Object);


            var factory = new CommandExecutorFactoryWithHttpContextAccessor(_accessorMock.Object);
            return factory;
        }

        [Fact]
        public void Get_Call_Provider_GetService()
        {
            var factory = QueryExecutorFactoryWithServiceProvider();

            var executorType = typeof(CommandExecutor<Command>);

            factory.Get(executorType);

            _accessorMock.Verify(p=>p.HttpContext,Times.Once);

        }
    }
}