using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Olbrasoft.AskMe.Data.EntityFrameworkCore.QueryHandlers;
using Olbrasoft.Mapping;
using Olbrasoft.Querying;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers
{
    public class QueryHandlerTest
    {
        [Test]
        public void Instance_Is_Handler()
        {
            //Arrange
            var type = typeof(AskQueryHandler<AwesomeQuery,  AwesomeResult,AwesomeEntity>);

            //Act
            var handler = AwesomeQueryHandler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        private static AwesomeQueryHandler AwesomeQueryHandler()
        {
            // var contextOptionMock = new Mock<DbContextOptions<AskDbContext>>();
            var contextMock = new Mock<AskDbContext>(MockBehavior.Strict);
            var projectorMock = new Mock<IProjector>();

            var handler = new AwesomeQueryHandler(projectorMock.Object, contextMock.Object);
            return handler;
        }
    }

    public class AwesomeQueryHandler : AskQueryHandler<AwesomeQuery, AwesomeResult, AwesomeEntity>
    {
       
        public override Task<AwesomeResult> HandleAsync(AwesomeQuery query, CancellationToken token) => throw new NotImplementedException();

        public AwesomeQueryHandler(IProjector projector, AskDbContext context) : base(projector, context)
        {
        }
    }

    public class AwesomeQuery : IQuery<AwesomeResult>
    {
        public AwesomeResult Execute() => throw new NotImplementedException();

        public Task<AwesomeResult> ExecuteAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
    }

    public class AwesomeEntity
    {
    }

    public class AwesomeResult
    {
    }
}