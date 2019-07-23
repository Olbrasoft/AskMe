using System.Linq;
using System.Reflection;
using Moq;
using Olbrasoft.Mapping;
using Xunit;

namespace Olbrasoft.Querying.Mapping
{
    public class QueryHandlerWithProjectorTest
    {
        private readonly Mock<IProjection> _projectorMock = new Mock<IProjection>();

        [Fact]
        public void Instance_Inherits_From_QueryHandler()
        {
            var type = typeof(QueryHandler<Query<bool>, bool>);

            var handler = AwesomeQueryHandler();

            Assert.IsAssignableFrom(type, handler);
        }

        private AwesomeQueryHandlerWithProjector AwesomeQueryHandler()
        {
            var handler = new AwesomeQueryHandlerWithProjector(_projectorMock.Object);
            return handler;
        }

        [Fact]
        public void ProjectTo_Call_Projector_Function_ProjectTo()
        {
            var handler = AwesomeQueryHandler();

            handler.Projection();

            _projectorMock.Verify(p => p.ProjectTo<bool>(It.IsAny<IQueryable<bool>>()), Times.Once);
        }

        [Fact]
        public void Method_ProjectTo_Is_Virtual()
        {
            var type = typeof(QueryHandlerWithProjector<,>);

            var method = type.GetMethod("ProjectTo", BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                CallingConventions.Any, new[] { typeof(IQueryable) }, null);

            Assert.True(method.IsVirtual);
        }
    }
}