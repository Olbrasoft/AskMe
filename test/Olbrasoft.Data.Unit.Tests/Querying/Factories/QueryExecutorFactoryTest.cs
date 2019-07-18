using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;
using Olbrasoft.Data.Querying.Factories;
using Olbrasoft.Dependence;

namespace Olbrasoft.Data.Unit.Tests.Querying.Factories
{
    [TestFixture]
    internal class QueryExecutorFactoryTest
    {
        [Test]
        public void Instance_Implement_Interface_IQueryExecutorFactory()
        {
            //Arrange
            var type = typeof(IQueryExecutorFactory);

            //Act
            var factory = Factory();

            //Assert
            Assert.IsInstanceOf(type, factory);
        }

        private static QueryExecutorFactory Factory()
        {
            var resolverMock = new Mock<IResolver>();
            var queryHandlerMock = new Mock<IQueryHandler<SomeQuery, AwesomeObject>>();

            resolverMock.Setup(p => p.Resolve(typeof(QueryExecutor<SomeQuery, AwesomeObject>)))
                .Returns(new QueryExecutor<SomeQuery, AwesomeObject>(queryHandlerMock.Object));

            var executorFactory = new QueryExecutorFactory(resolverMock.Object);
            return executorFactory;

        }

        [Test]
        public void Get_Return_IQueryExecutor_Of_SomeObject()
        {
            //Arrange
            var type = typeof(IQueryExecutor<AwesomeObject>);
            var factory = Factory();

            //Act
            var executor = factory.Get<AwesomeObject>(typeof(QueryExecutor<SomeQuery, AwesomeObject>));

            //Assert
            Assert.IsInstanceOf(type, executor);
        }
    }
}