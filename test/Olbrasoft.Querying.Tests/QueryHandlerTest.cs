using Moq;
using Xunit;

namespace Olbrasoft.Querying
{
    public class QueryHandlerTest
    {
        [Fact]
        public void Instance_Implement_Interface_IQueryHandler_Of_AwesomeQuery_Comma_bool()
        {
            var type = typeof(IQueryHandler<Query<bool>, bool>);

            var handler = new AwesomeQueryHandler();

            Assert.IsAssignableFrom(type, handler);
        }

        [Fact]
        public void Handle_Return_True()
        {
            var dispatcherMock = new Mock<IQueryDispatcher>();
            var query = new Query<bool>(dispatcherMock.Object);

            var result = new AwesomeQueryHandler().Handle(query);

            Assert.True((bool) result);
        }

        [Fact]
        public void Source()
        {
            var handler = new AwesomeQueryHandler();

            var source = handler.Source;

            Assert.IsAssignableFrom<int[]>(source);
        }
    }
}