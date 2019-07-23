using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Olbrasoft.Commanding.EntityFrameworkCore
{
    public class CommandHandlerWithDbContextTest
    {
        [Fact]
        public void Is_Abstract()
        {
            var type = typeof(CommandHandlerWithDbContext<,>);

            Assert.True(type.IsAbstract);
        }

        [Fact]
        public void AwesomeCommandHandlerWithDbContext_Inherits_From_CommandHandlerWithDbContext()
        {
            var handler = CreateHandler();

            Assert.IsAssignableFrom<CommandHandlerWithDbContext<Command, DbContext>>(handler);
        }

        private static AwesomeCommandHandlerWithDbContext CreateHandler()
        {
            var contextMock = new Mock<DbContext>();
            var handler = new AwesomeCommandHandlerWithDbContext(contextMock.Object);
            return handler;
        }

        [Fact]
        public void CommandHandlerWithDbContext_Inherits_From_CommandHandler()
        {
            var handler = CreateHandler();

            Assert.IsAssignableFrom<CommandHandler<Command>>(handler);
        }
    }
}