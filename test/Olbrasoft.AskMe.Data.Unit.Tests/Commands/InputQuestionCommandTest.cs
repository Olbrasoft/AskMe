using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Commands;
using Altairis.AskMe.Data.Transfer.Objects;
using Moq;
using NUnit.Framework;
using Olbrasoft.Commanding;

namespace Olbrasoft.AskMe.Data.Unit.Tests.Commands
{
    public class InputQuestionCommandTest
    {
        [Test]
        public void Instance_Is_Command_Of_UnansweredQuestionDto()
        {
            //Arrange
            var type = typeof(Command<InputQuestionDto>);

            //Act
            var command = InsertQuestionCommand();

            //Assert
            Assert.IsInstanceOf(type, command);
        }

        private static InsertQuestionCommand InsertQuestionCommand()
        {
            var dispatcherMock = new Mock<ICommandDispatcher>();

            var command = new InsertQuestionCommand(dispatcherMock.Object);
            return command;
        }
    }
}