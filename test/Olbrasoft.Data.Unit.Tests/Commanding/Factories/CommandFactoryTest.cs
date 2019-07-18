using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Commanding;
using Olbrasoft.Data.Commanding.Factories;
using Olbrasoft.Dependence;

namespace Olbrasoft.Data.Unit.Tests.Commanding.Factories
{
    public class CommandFactoryTest
    {
        [Test]
        public void Instance_Implement_Interface_ICommandFactory()
        {
            //Arrange
            var type = typeof(ICommandFactory);

            //Act
            var factory = CommandFactory();

            //Assert
            Assert.IsInstanceOf(type, factory);
        }

        [Test]
        public void Get_Return_ICommand()
        {
            //Arrange
            var factory = CommandFactory();

            //Act
            var result = factory.Get<AwesomeCommand>();

            //Assert
            Assert.IsInstanceOf<AwesomeCommand>(result);

        }

        private static CommandFactory CommandFactory()
        {
            var resolverMock = new Mock<IResolver>();
            var dispatcherMock = new Mock<ICommandDispatcher>();
            resolverMock.Setup(p => p.Resolve(typeof(AwesomeCommand))).Returns(new AwesomeCommand(dispatcherMock.Object));

            var factory = new CommandFactory(resolverMock.Object);
            return factory;
        }
    }
}