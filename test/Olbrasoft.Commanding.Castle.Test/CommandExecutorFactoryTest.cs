using Castle.Windsor;
using Moq;
using Xunit;

namespace Olbrasoft.Commanding.Castle
{
    public class CommandExecutorFactoryTest
    {
        [Fact]
        public void Instance_Implement_Interface_ICommandExecutorFactory()
        {
            var containerMock = new Mock<IWindsorContainer>();

            var factory = new CommandExecutorFactory(containerMock.Object);

            Assert.IsAssignableFrom<ICommandExecutorFactory>(factory);
        }
    }
}
