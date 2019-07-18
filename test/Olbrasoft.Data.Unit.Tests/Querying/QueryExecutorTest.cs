using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Unit.Tests.Querying
{
    [TestFixture]
    internal class QueryExecutorTest
    {
        [Test]
        public void Instance_Implement_Interface_IQueryExecutor()
        {
            //Arrange
            var type = typeof(IQueryExecutor<AwesomeObject>);

            //Act
            var executor = Executor();

            //Assert
            Assert.IsInstanceOf(type, executor);
        }

        private static QueryExecutor<SomeQuery, AwesomeObject> Executor()
        {
            var queryHandlerMock = new Mock<IQueryHandler<SomeQuery, AwesomeObject>>();
            queryHandlerMock.Setup(p => p.Handle(It.IsAny<SomeQuery>())).Returns(new AwesomeObject());

            var executor = new QueryExecutor<SomeQuery, AwesomeObject>(queryHandlerMock.Object);
            return executor;
        }

        [Test]
        public void Execute_Return_Object()
        {
            //Arrange
            var type = typeof(object);
            var executor = Executor();
            var query = Query();

            //Act
            var result = executor.Execute(query);

            //Assert
            Assert.IsInstanceOf(type, result);
        }

        private static SomeQuery Query()
        {
            var queryDispatcherMock = new Mock<IQueryDispatcher>();
            var query = new SomeQuery(queryDispatcherMock.Object);
            return query;
        }

        [Test]
        public void ExecuteAsync_Return_TaskOfObject()
        {
            //Arrange
            var type = typeof(Task<AwesomeObject>);
            var executor = Executor();
            var query = Query();

            //Act
            var result = executor.ExecuteAsync(query);

            //Assert
            Assert.IsInstanceOf(type, result);
        }
    }
}