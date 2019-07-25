using Castle.Windsor;
using Moq;
using Xunit;

namespace Olbrasoft.Commanding.DependencyInjection.Castle
{
    public class CommandExecutorFactoryTest
    {
        [Fact]
        public void Instance_Implement_Interface_ICommandExecutorFactory()
        {
            var factory = CommandExecutorFactoryWithWindsorContainer();

            Assert.IsAssignableFrom<ICommandExecutorFactory>(factory);
        }

        private static CommandExecutorFactoryWithWindsorContainer CommandExecutorFactoryWithWindsorContainer()
        {
            var containerMock = new Mock<IWindsorContainer>();

            var factory = new CommandExecutorFactoryWithWindsorContainer(containerMock.Object);
            return factory;
        }

        [Fact]
        public void Inherits_From_BaseCommandExecutorFactory()
        {
            var type = typeof(BaseCommandExecutorFactory);

            var factory = CommandExecutorFactoryWithWindsorContainer();


            Assert.IsAssignableFrom(type ,factory);

        }

    }
}
