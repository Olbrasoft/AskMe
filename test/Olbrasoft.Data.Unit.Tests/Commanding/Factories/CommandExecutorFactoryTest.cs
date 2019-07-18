using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Commanding;
using Olbrasoft.Data.Commanding.Factories;
using Olbrasoft.Dependence;

namespace Olbrasoft.Data.Unit.Tests.Commanding.Factories
{
    public class CommandExecutorFactoryTest
    {
        [Test]
        public void Instance_Implement_Interface_ICommandHandlerFactory()
        {
            //Arrange
            var type = typeof(ICommandExecutorFactory);

            //Act
            var factory = CommandExecutorFactory();

            //Assert
            Assert.IsInstanceOf(type, factory);
        }

        private static CommandExecutorFactory CommandExecutorFactory()
        {
            var resolverMock = new Mock<IResolver>();
           

            var factory = new CommandExecutorFactory(resolverMock.Object);
            return factory;
        }
    }
}