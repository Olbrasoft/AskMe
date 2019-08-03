using System.Threading.Tasks;
using Altairis.AskMe.Data.Commands;

using Moq;
using NUnit.Framework;
using Olbrasoft.AskMe.Data.EntityFrameworkCore.CommandHandlers;
using Olbrasoft.Commanding;
using Olbrasoft.Commanding.Mapping.EntityFrameworkCore;
using Olbrasoft.Mapping;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.Unit.Tests.CommandHandlers
{
    public class InsertQuestionCommandHandlerTest
    {

        [Test]
        public void Instance_Is_AskCommandHandler_Of_InsertQuestionCommand()
        {
            //Arrange
            var type = typeof(CommandHandlerWithMapperAndDbContext<InsertQuestionCommand,AskDbContext>);

            //Act
            var handler = InputQuestionCommandHandler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        [Test]
        public void HandleAsync_Return_Task()
        {
            //Arrange
            var handler = InputQuestionCommandHandler();

            var dispatcherMock = new Mock<ICommandDispatcher>();
            var command = new InsertQuestionCommand(dispatcherMock.Object);

            //Act
            var result = handler.HandleAsync(command);

            //Assert
            Assert.IsInstanceOf<Task>(result);
        }

        private static InsertQuestionCommandHandler InputQuestionCommandHandler()
        {
            var contextMock = new Mock<AskDbContext>();
            var mapperMock = new Mock<IMapper>();

            var handler = new InsertQuestionCommandHandler(mapperMock.Object, contextMock.Object);
            return handler;
        }
    }
}