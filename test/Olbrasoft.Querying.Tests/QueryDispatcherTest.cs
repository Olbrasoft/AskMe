using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Olbrasoft.Querying
{
    public class QueryDispatcherTest
    {
        [Fact]
        public void Instance_Implement_Interface_IQueryDispatcher()
        {
            //Arrange
            var type = typeof(IQueryDispatcher);

            //Act
            var dispatcher = Dispatcher();

            //Assert
            Assert.IsAssignableFrom(type, dispatcher);
        }

        [Fact]
        public void Dispatch_Return_True()
        {
            //Arrange
            var dispatcher = Dispatcher();

            //Act
            var result = dispatcher.Dispatch(new Query<bool>(dispatcher));

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void DispatchAsync_Return_Task_Of_SomeObject()
        {
            //Arrange
            var dispatcher = Dispatcher();

            //Act
            var result = dispatcher.DispatchAsync(new Query<bool>(dispatcher));

            //Assert
            Assert.IsAssignableFrom<Task<bool>>(result);
        }

        private static QueryDispatcher Dispatcher()
        {
            var executorFactoryMock = new Mock<IQueryExecutorFactory>();
            var executorMock = new Mock<IQueryExecutor<bool>>();
            executorMock.Setup(p => p.Execute(It.IsAny<Query<bool>>())).Returns(true);
            executorMock.Setup(p => p.ExecuteAsync(It.IsAny<Query<bool>>(), default)).Returns(Task.FromResult(true));

            executorFactoryMock.Setup(p => p.Get<bool>(typeof(QueryExecutor<Query<bool>, bool>)))
                .Returns( executorMock.Object);

            var dispatcher = new QueryDispatcher(executorFactoryMock.Object);
            return dispatcher;
        }
    }
}