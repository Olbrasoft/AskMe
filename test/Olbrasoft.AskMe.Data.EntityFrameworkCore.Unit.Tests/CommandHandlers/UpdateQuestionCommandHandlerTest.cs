using Altairis.AskMe.Data.Commands;
using Moq;
using NUnit.Framework;
using Olbrasoft.AskMe.Data.EntityFrameworkCore.CommandHandlers;
using Olbrasoft.Data.Commanding;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.Unit.Tests.CommandHandlers
{
    public class UpdateQuestionCommandHandlerTest
    {
        [Test]
        public void Instance_Is_CommandHandler_Of_UpdateQuestionCommand()
        {
            //Arrange
            var type = typeof(CommandHandler<UpdateQuestionCommand>);

            //Act
            var handler = UpdateQuestionCommandHandler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        private static UpdateQuestionCommandHandler UpdateQuestionCommandHandler()
        {
            var contextMock = new Mock<AskDbContext>();

            var handler = new UpdateQuestionCommandHandler(contextMock.Object);
            return handler;
        }


        [Test]
        public void HandleAsync()
        {
            //Arrange


            //Act


            //Assert

        }
    }
}