using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Olbrasoft.Commanding
{
    public class CommandDispatcherTest
    {
        [Fact]
        public void Instance_Implement_Interface_ICommandDispatcher()
        {
            var type = typeof(ICommandDispatcher);

            var dispatcher = CommandDispatcher();

            Assert.IsAssignableFrom(type, dispatcher);
        }

        private static CommandDispatcher CommandDispatcher()
        {
            var factoryMock = new Mock<ICommandExecutorFactory>();
            factoryMock.Setup(p => p.CreateExecutor(typeof(CommandExecutor<Command<bool>>)))
                .Returns(new Mock<ICommandExecutor>().Object);

            var dispatcher = new CommandDispatcher(factoryMock.Object);

            return dispatcher;
        }

        [Fact]
        public void Dispatch()
        {
            var dispatcher = CommandDispatcher();

            var command = new Command<bool>(dispatcher);

            dispatcher.Dispatch(command);
        }

        [Fact]
        public void DispatchAsync_Return_Task()
        {
            var dispatcher = CommandDispatcher();

            var command = new Command<bool>(dispatcher);

            var result = dispatcher.DispatchAsync(command, default);

            Assert.IsAssignableFrom<Task>(result);

        }
    }
}