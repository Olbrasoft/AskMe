using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Unit.Tests.Querying
{
    [TestFixture]
    internal class QueryDispatcherTest
    {
        [Test]
        public void Instance_Implement_Interface_IQueryDispatcher()
        {
            //Arrange
            var type = typeof(IQueryDispatcher);

            //Act
            var dispatcher = Dispatcher();

            //Assert
            Assert.IsInstanceOf(type, dispatcher);
        }

        [Test]
        public void Dispatch_Return_SomeObject()
        {
            //Arrange
            var type = typeof(AwesomeObject);
            var dispatcher = Dispatcher();

            //Act
            var result = dispatcher.Dispatch(new SomeQuery(dispatcher));

            //Assert
            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void DispatchAsync_Return_Task_Of_SomeObject()
        {
            //Arrange
            var type = typeof(Task<AwesomeObject>);
            var dispatcher = Dispatcher();

            //Act
            var result = dispatcher.DispatchAsync(new SomeQuery(dispatcher));

            //Assert
            Assert.IsInstanceOf(type, result);
        }

        private static QueryDispatcher Dispatcher()
        {
            var executorFactoryMock = new Mock<IQueryExecutorFactory>();
            var executorMock = new Mock<IQueryExecutor<AwesomeObject>>();
            executorMock.Setup(p => p.Execute(It.IsAny<SomeQuery>())).Returns(new AwesomeObject());
            executorMock.Setup(p => p.ExecuteAsync(It.IsAny<SomeQuery>(), default(CancellationToken))).Returns(Task.FromResult(new AwesomeObject()));

            executorFactoryMock.Setup(p => p.Get<AwesomeObject>(typeof(QueryExecutor<SomeQuery, AwesomeObject>)))
                .Returns(executorMock.Object);

            var dispatcher = new QueryDispatcher(executorFactoryMock.Object);
            return dispatcher;
        }
    }
}