using Moq;
using NUnit.Framework;
using Olbrasoft.AskMe.Business.Services;
using Olbrasoft.Data.Commanding;
using Olbrasoft.Data.Querying;

namespace Olbrasoft.AskMe.Business.Tests.Services
{
    [TestFixture]
    internal class ServiceTest
    {
        private static AwesomeService Facade()
        {
            var queryFactoryMock = new Mock<IQueryFactory>();
            var commandFactoryMock = new Mock<ICommandFactory>();

            return new AwesomeService(commandFactoryMock.Object, queryFactoryMock.Object);
        }

        [Test]
        public void Instance_Is_Facade()
        {
            //Arrange
            var type = typeof(Service);

            //Act
            var facade = Facade();

            //Assert
            Assert.IsInstanceOf(type, facade);
        }

        [Test]
        public void QueryProvider_Implement_Interface_IProvider()
        {
            //Arrange
            var facade = Facade();

            //Act
            var provider = facade.QueryFactory;

            //Assert
            Assert.IsInstanceOf<IQueryFactory>(provider);
        }
    }
}