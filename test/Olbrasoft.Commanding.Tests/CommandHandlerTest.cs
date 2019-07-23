using Moq;
using Xunit;

namespace Olbrasoft.Commanding
{
    public class CommandHandlerTest
    {
        [Fact]
        public void Instance_Implement_Interface_ICommandHandler_Of_Command()
        {
            var type = typeof(ICommandHandler<Command>);

            var handler = new AwesomeCommandHandler();

            Assert.IsAssignableFrom(type, handler);
        }

        [Fact]
        public void Handle()
        {
            var handler = new AwesomeCommandHandler();

            var dispatcher = new Mock<ICommandDispatcher>();

            handler.Handle(new Command(dispatcher.Object));
        }
    }

}