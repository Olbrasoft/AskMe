using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Olbrasoft.AskMe.Data.EntityFrameworkCore.QueryHandlers;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Querying;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers
{
    public class QueryHandlerTest
    {
        [Test]
        public void Instance_Is_Handler()
        {
            //Arrange
            var type = typeof(Handler<AwesomeQuery, IQueryable<AwesomeEntity>, AwesomeResult>);

            //Act
            var handler = AwesomeQueryHandler();

            //Assert
            Assert.IsInstanceOf(type,handler);
        }

        private static AwesomeQueryHandler AwesomeQueryHandler()
        {
           // var contextOptionMock = new Mock<DbContextOptions<AskDbContext>>();
            var contextMock = new Mock<AskDbContext>(MockBehavior.Strict);
            var projectorMock = new Mock<IProjection>();
            
            var handler = new AwesomeQueryHandler(contextMock.Object,projectorMock.Object);
            return handler;
        }
    }




    public class AwesomeQueryHandler :QueryHandler<AwesomeQuery,AwesomeEntity,AwesomeResult>
    {
        public AwesomeQueryHandler(AskDbContext context, IProjection projector) : base(context, projector)
        {
        }

        public override Task<AwesomeResult> HandleAsync(AwesomeQuery query, CancellationToken token) => throw new NotImplementedException();
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
