using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;

namespace Olbrasoft.Data.Unit.Tests.Querying
{
    public class QueryTest
    {
        [Test]
        public void Instance_Implement_Interface_IQuery_Of_SomeObject()
        {
            //Arrange
            var type = typeof(IQuery<AwesomeObject>);
            var queryDispatcherMock = new Mock<IQueryDispatcher>();

            //Act
            var query = new SomeQuery(queryDispatcherMock.Object);

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Execute()
        {
            //Arrange
            var someObject = new AwesomeObject();
            var queryDispatcherMock = new Mock<IQueryDispatcher>();
            var query = new SomeQuery(queryDispatcherMock.Object);

            queryDispatcherMock.Setup(p => p.Dispatch(query)).Returns(someObject);

            //Act
            var result = query.Execute();

            //Assert
            Assert.AreSame(someObject, result);
        }

        

        [Test]
        public void ExecuteAsync()
        {
            //Arrange
            var queryDispatcherMock = new Mock<IQueryDispatcher>();
            var query = new SomeQuery(queryDispatcherMock.Object);

            //Act
            var result = query.ExecuteAsync();

            //Assert
            Assert.IsInstanceOf(typeof(Task<AwesomeObject>), result);
        }
    }
}