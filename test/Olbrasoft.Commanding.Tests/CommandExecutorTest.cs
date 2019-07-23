using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Olbrasoft.Commanding
{
    public class CommandExecutorTest
    {
        private Mock<ICommandHandler<Command<bool>>> _handlerMock;

        private Mock<ICommandHandler<Command<bool>>> HandlerMock => _handlerMock ?? (_handlerMock = new Mock<ICommandHandler<Command<bool>>>());

        private ICommandDispatcher Dispatcher => new Mock<ICommandDispatcher>().Object;
        
        
        [Fact]
        public void Instance_Implement_Interface()
        {
            var type = typeof(ICommandExecutor);

            var executor = Executor();

            Assert.IsAssignableFrom(type, executor);
        }

        [Fact]
        public void Execute()
        {
            var command = new Command<bool>(Dispatcher);

            var executor = Executor();

            executor.Execute(command);

            HandlerMock.Verify(mock => mock.Handle(command));
        }

        [Fact]
        public void ExecuteAsync_Return_Task()
        {
            var command = new Command<bool>(Dispatcher);

            var result = Executor().ExecuteAsync(command, default);

            Assert.IsAssignableFrom<Task>(result);
        }

        private CommandExecutor<Command<bool>> Executor()
        {
            var executor = new CommandExecutor<Command<bool>>(HandlerMock.Object);
            return executor;
        }
    }
}