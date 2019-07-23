using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Olbrasoft.Commanding
{
    public class CommandTest
    {
        private Mock<ICommandDispatcher> _dispatcherMock;

        private Mock<ICommandDispatcher> DispatcherMock => _dispatcherMock ?? (_dispatcherMock = new Mock<ICommandDispatcher>());

        [Fact]
        public void Instance_Implement_Interface_ICommand_Of_bool()
        {
            var type = typeof(ICommand<bool>);

            var command = Command();

            Assert.IsAssignableFrom(type, command);
        }

        private Command<bool> Command()
        {
            var command = new Command<bool>(DispatcherMock.Object);
            return command;
        }

        [Fact]
        public void Execute()
        {
            var command = Command();

            command.Execute();

            DispatcherMock.Verify(mock => mock.Dispatch(command), Times.Once());
        }


        [Fact]
        public void ExecuteAsync_Return_Task()
        {
            var command = Command();

            var result = command.ExecuteAsync(default);

            Assert.IsAssignableFrom<Task>(result);
        }
        
    }
}