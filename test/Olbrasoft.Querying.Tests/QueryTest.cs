using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Olbrasoft.Querying
{
    public class QueryTest
    {
        [Fact]
        public void Instance_Implement_Interface_IQuery_Of_Bool()
        {
            var type = typeof(IQuery<bool>);

            var query = Query();

            Assert.IsAssignableFrom(type, query);
        }

        [Fact]
        public void Execute()
        {
            //Arrange
            var query = Query();

            //Act
            var result = query.Execute();

            //Assert
            Assert.True((bool) result);
        }

        [Fact]
        public void ExecuteAsync()
        {
            //Arrange
            var query = Query();

            //Act
            var result = query.ExecuteAsync();

            //Assert
            Assert.IsAssignableFrom<Task<bool>>(result);
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