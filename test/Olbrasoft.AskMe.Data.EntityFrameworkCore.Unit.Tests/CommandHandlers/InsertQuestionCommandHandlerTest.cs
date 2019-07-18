using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Commands;
using Moq;
using NUnit.Framework;
using Olbrasoft.AskMe.Data.EntityFrameworkCore.CommandHandlers;
using Olbrasoft.AskMe.Data.EntityFrameworkCore.QueryHandlers;
using Olbrasoft.Data.Commanding;
using Olbrasoft.Data.Mapping;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.Unit.Tests.CommandHandlers
{
    public class InsertQuestionCommandHandlerTest
    {
        [Test]
        public void Instance_Is_AskCommandHandler_Of_InsertQuestionCommand()
        {
            //Arrange
            var type = typeof(AskCommandHandler<InsertQuestionCommand>);

            //Act
            var handler = InsertQuestionCommandHandler();

            //Assert
            Assert.IsInstanceOf(type,handler);
        }

        [Test]
        public void HandleAsync_Return_Task()
        {
            //Arrange
            var handler = InsertQuestionCommandHandler();

            var dispatcherMock = new Mock<ICommandDispatcher>();
            var command = new InsertQuestionCommand(dispatcherMock.Object);

            //Act
            var result = handler.HandleAsync(command);

            //Assert
            Assert.IsInstanceOf<Task>(result);
        }

        private static InsertQuestionCommandHandler InsertQuestionCommandHandler()
        {
            var mapperMock = new Mock<IMap>();
            var contextMock = new Mock<AskDbContext>();

            var handler = new InsertQuestionCommandHandler(contextMock.Object);
            return handler;
        }
    }
}
