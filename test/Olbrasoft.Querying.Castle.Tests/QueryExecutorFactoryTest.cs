using Castle.Windsor;
using Moq;
using Xunit;

namespace Olbrasoft.Querying.Castle
{
    public class QueryExecutorFactoryTest
    {
        [Fact]
        public void Instance_Implement_Interface_IQueryExecutorFactory()
        {
            var containerMock = new Mock<IWindsorContainer>();

            var factory = new QueryExecutorFactory(containerMock.Object);

            Assert.IsAssignableFrom<IQueryExecutorFactory>(factory);
        }
    }
}