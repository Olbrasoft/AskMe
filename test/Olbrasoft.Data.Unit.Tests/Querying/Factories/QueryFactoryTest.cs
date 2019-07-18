using System;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;
using Olbrasoft.Data.Querying.Factories;
using Olbrasoft.Dependence;

namespace Olbrasoft.Data.Unit.Tests.Querying.Factories
{
    [TestFixture]
    internal class QueryFactoryTest
    {
        [Test]
        public void Instance_Implement_Interface_IQueryFactory()
        {
            //Arrange
            var type = typeof(IQueryFactory);

            //Act
            var factory = QueryFactory();

            //Assert
            Assert.IsInstanceOf(type, factory);
        }

        [Test]
        public void Get_Return_IQuery()
        {
            //Arrange
            var type = typeof(IQuery);
            var factory = QueryFactory();

            //Act
            var query = factory.Get<SomeQuery>();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        private static QueryFactory QueryFactory()
        {
            var resolverMock = new Mock<IResolver>();
            var queryDispatcherMock = new Mock<IQueryDispatcher>();

            resolverMock.Setup(p => p.Resolve(It.IsAny<Type>())).Returns(new SomeQuery(queryDispatcherMock.Object));

            var factory = new QueryFactory(resolverMock.Object);
            return factory;
        }
    }

   
}