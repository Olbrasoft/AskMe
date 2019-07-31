using Moq;
using Xunit;

namespace Olbrasoft.Commanding.Business
{
    public class ServiceWithCommandFactoryTest
    {
        [Fact]
        public void Test1()
        {
            var factoryMock = new Mock<ICommandFactory>();

            var service = new AwesomeServiceWithCommandFactory(factoryMock.Object);

            service.CallGetCommand();

            factoryMock.Verify(p => p.CreateCommand<Command>(), Times.Once);

        }

    }
}
