using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Querying;

namespace Olbrasoft.Data.Unit.Tests.Querying
{
    public class HandlerTest
    {
        [Test]
        public void Instance_Implement_Interface_IQueryHandler()
        {
            //Arrange
            var type = typeof(IQueryHandler<AwesomeQuery, object>);

            //Act
            var handler = new AwesomeQueryHandler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        [Test]
        public void QueryHandler_Is_Abstract()
        {
            //Arrange
            var type = typeof(Handler<AwesomeQuery, object>);

            //Act
            var result = type.IsAbstract;

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void HandleAsync()
        {
            //Arrange
            var handler = new AwesomeQueryHandler();

            //Act
            var result = handler.HandleAsync(new AwesomeQuery());

            //Assert
            Assert.IsInstanceOf<Task<object>>(result);
        }

        [Test]
        public void Handle()
        {
            //Arrange
            var handler = new AwesomeQueryHandler();

            //Act
            var result = handler.Handle(new AwesomeQuery());

            //Assert
            Assert.IsInstanceOf<object>(result);
        }

        [Test]
        public void Instance_Is_Handler_Of()
        {
            //Arrange
            var type = typeof(Handler<AwesomeQuery, AwesomeSource, object>);

            //Act
            var handler = NextQueryHandler();

            //Assert
            Assert.IsInstanceOf(type,handler);
        }

        private static AwesomeNextQueryHandler NextQueryHandler()
        {
            var projectorMock = new Mock<IProjection>();

            var handler = new AwesomeNextQueryHandler(projectorMock.Object);
            return handler;
        }


        [Test]
        public void Source()
        {
            //Arrange
            var handler = NextQueryHandler();

            //Act
            var source = handler.Source;

            //Assert
            Assert.IsInstanceOf<AwesomeSource>(source);

        }


        [Test]
        public void ProjectTo()
        {
            //Arrange
            var handler = NextQueryHandler();

            //Act
            var result = handler.ProjectTo<object>(new List<string>().AsQueryable() );

            //Assert
            Assert.IsInstanceOf<object>(result);
        }


    }

    internal class AwesomeSource
    {
    }


    public class AwesomeQuery : IQuery<object>
    {
        public object Execute()
        {
            throw new NotImplementedException();
        }

        public Task<object> ExecuteAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}