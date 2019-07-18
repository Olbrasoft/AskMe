using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;

namespace Olbrasoft.Data.Unit.Tests.Querying
{
    [TestFixture]
    internal class HandlerWithDependentSourceTest
    {
        [Test]
        public void Is_Instance_Of_IQueryHandler()
        {
            //Arrange
            var type = typeof(IHandle<SomQuery, object>);

            //Act
            var someQueryHandler = CreateSomeQueryHandler();

            //Assert
            Assert.IsInstanceOf(type, someQueryHandler);
        }

        private static SomeQueryHandlerWithDependentSource CreateSomeQueryHandler()
        {
            var objectQueryableMock = new Mock<IHaveQueryable<object>>();

            var source = objectQueryableMock.Object;

            return new SomeQueryHandlerWithDependentSource(source);
        }

       

        [Test]
        public void Handle()
        {
            //Arrange
            var handler = CreateSomeQueryHandler();

            //Act
            var result = handler.Handle(new SomQuery());

            //Assert
            Assert.IsNotNull(result);
        }
    }
}

