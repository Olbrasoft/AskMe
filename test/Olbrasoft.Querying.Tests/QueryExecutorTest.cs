using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Olbrasoft.Querying
{
    public class QueryExecutorTest
    {
        [Fact]
        public void Instance_Implement_Interface_IQueryExecutor()
        {
            //Arrange
            var type = typeof(IQueryExecutor<bool>);

            //Act
            var executor = Executor();

            //Assert
            Assert.IsAssignableFrom(type, executor);
        }

        [Fact]
        public void Execute_Return_True()
        {
            //Arrange
            var executor = Executor();
            var query = Query();

            //Act
            var result = executor.Execute(query);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void ExecuteAsync_Return_TaskOfObject()
        {
            //Arrange
            var executor = Executor();
            var query = Query();

            //Act
            var result = executor.ExecuteAsync(query);

            //Assert
            Assert.IsAssignableFrom<Task<bool>>(result);
        }

        private static QueryExecutor<Query<bool>, bool> Executor()
        {
            var queryHandlerMock = new Mock<IQueryHandler<Query<bool>, bool>>();
            queryHandlerMock.Setup(p => p.Handle(It.IsAny<Query<bool>>())).Returns(true);

            var executor = new QueryExecutor<Query<bool>, bool>(queryHandlerMock.Object);
            return executor;
        }
        
        private static Query<bool> Query()
        {
            var dispatcherMock = new Mock<IQueryDispatcher>();
            var query = new Query<bool>(dispatcherMock.Object);
            dispatcherMock.Setup(p => p.Dispatch(query)).Returns(true);

            return query;
        }
        
    }
}