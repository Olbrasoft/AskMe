using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Commanding;

namespace Olbrasoft.Data.Unit.Tests.Commanding
{
    public class CommandTest
    {
        [Test]
        public void Instance_Implement_Interface_ICommand()
        {
            //Arrange
            var type = typeof(ICommand);

            //Act
            var command = AwesomeCommand();

            //Assert
            Assert.IsInstanceOf(type,command);
        }

        private static AwesomeCommand AwesomeCommand()
        {
            var dispatcherMock = new Mock<ICommandDispatcher>();

            var command = new AwesomeCommand(dispatcherMock.Object);
            return command;
        }
    }
}
