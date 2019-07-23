using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Moq;
using Olbrasoft.Mapping;
using Xunit;

namespace Olbrasoft.Querying.Mapping.EntityFrameworkCore
{
    public class QueryHandlerWithProjectorAndDbContextTest
    {
        private readonly Mock<DbContext> _contextMock = new Mock<DbContext>();

        [Fact]
        public void Instance_Inherits_From_Mapping_QueryHandler()
        {
            var type = typeof(QueryHandlerWithProjector<Query<bool>, bool>);
            var handler = AwesomeQueryHandler();

            Assert.IsAssignableFrom(type, handler);
        }

        [Fact]
        public void Entities_Is_Virtual()
        {
            var type = typeof(QueryHandlerWithProjectorAndDbContext<,,,>);

            var method = type.GetMethod("Entities", BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                CallingConventions.Any, new Type[0], null);

            Assert.True(method.IsVirtual);
        }

        [Fact]
        public void Entities_Call_Context_Method_Set()
        {
            var handler = AwesomeQueryHandler();

            handler.BuildEntities();

            _contextMock.Verify(p => p.Set<AwesomeEntity>(), Times.Once);
        }

        private AwesomeDbQueryHandler AwesomeQueryHandler()
        {
            var projectorMock = new Mock<IProjection>();

            var handler = new AwesomeDbQueryHandler(projectorMock.Object, _contextMock.Object);
            return handler;
        }
    }
}