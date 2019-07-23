using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Olbrasoft.Querying.EntityFrameworkCore.Tests
{
    public class QueryHandlerWithDbContextTest
    {
        private readonly Mock<DbContext> _contextMock = new Mock<DbContext>();

        [Fact]
        public void QueryHandlerWithDbContext_Is_Abstract()
        {
            var type = typeof(QueryHandlerWithDbContext<Query<bool>, bool, AwesomeEntity, DbContext>);

            var result = type.IsAbstract;

            Assert.True(result);
        }

        [Fact]
        public void AwesomeQueryHandlerWithDbContext_Inherits_From_QueryHandlerWithDbContext()
        {
            var type = typeof(QueryHandlerWithDbContext<Query<bool>, bool, AwesomeEntity, DbContext>);

            var handler = CreateHandler();

            Assert.IsAssignableFrom(type, handler);
        }

        
        private  AwesomeQueryHandlerWithDbContext CreateHandler()
        {
            var handler = new AwesomeQueryHandlerWithDbContext(_contextMock.Object);
            return handler;
        }

        [Fact]
        public void Instance_Inherits_From_QueryHandler()
        {
            var handler = CreateHandler();

            Assert.IsAssignableFrom<QueryHandler<Query<bool>, bool>>(handler);
        }

        [Fact]
        public void Entities_Call_Context_Method_Set()
        {
            var handler = CreateHandler();

            handler.CallBaseEntities();

            _contextMock.Verify(p=>p.Set<AwesomeEntity>(), Times.Once);
        }
    }
}