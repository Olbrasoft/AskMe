using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.ModelBuilder.Descriptors;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Commanding;
using Olbrasoft.Data.Mapping;

namespace Olbrasoft.Data.Unit.Tests.Commanding
{
    public class CommandHandlerTest
    {
        [Test]
        public void Instance_Is_ICommandHandler_Of_AwesomeCommand()
        {
            //Arrange
            var type = typeof(ICommandHandler<AwesomeCommand>);

            //Act
            var handler = AwesomeCommandHandler();
            
            //Assert
            Assert.IsInstanceOf(type,handler);
        }

        private static AwesomeCommandHandler AwesomeCommandHandler()
        {
            var mapperMock = new Mock<IMap>();

            var handler = new AwesomeCommandHandler();
            return handler;
        }

        [Test]
        public void Handle()
        {
            //Arrange


            //Act


            //Assert

        }
    }
}
