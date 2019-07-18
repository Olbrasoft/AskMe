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
    public class CommandExecutorTest
    {
        [Test]
        public void Instance_Implement_Interface_ICommandExecutor()
        {
            //Arrange
            var type = typeof(ICommandExecutor);

            //Act
            var executor = CommandExecutor();


            //Assert
            Assert.IsInstanceOf(type,executor);
        }

        private static CommandExecutor<AwesomeCommand> CommandExecutor()
        {
            
            var executor = new CommandExecutor<AwesomeCommand>(new AwesomeCommandHandler());
            return executor;
        }
    }
}
