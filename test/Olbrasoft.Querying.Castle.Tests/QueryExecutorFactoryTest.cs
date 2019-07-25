using Castle.Windsor;
using Moq;
using Olbrasoft.Querying.DependencyInjection;
using Olbrasoft.Querying.DependencyInjection.Castle;
using Xunit;

namespace Olbrasoft.Querying.Castle
{
    public class QueryExecutorFactoryTest
    {
        [Fact]
        public void Instance_Implement_Interface_IQueryExecutorFactory()
        {
            var type = typeof(IQueryExecutorFactory);

            var factory = QueryExecutorFactory();

            Assert.IsAssignableFrom(type, factory);
        }

        private static QueryExecutorFactory QueryExecutorFactory()
        {
            var containerMock = new Mock<IWindsorContainer>();

            var factory = new QueryExecutorFactory(containerMock.Object);
            return factory;
        }

        [Fact]
        public void Instance_Inherits_From_BaseQueryExecutorFactory()
        {
            var type = typeof(BaseQueryExecutorFactory);

            var factory = QueryExecutorFactory();

            Assert.IsAssignableFrom(type,factory);


        }

    }
}