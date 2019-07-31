using Moq;
using Olbrasoft.Commanding;
using Olbrasoft.Commanding.Business;
using Olbrasoft.Querying;
using Xunit;

namespace Olbrasoft.CommandingAndQuerying.Business.Tests
{
    public class ServiceWithCommandFactoryAndQueryFactoryTest
    {
        readonly Mock<IQueryFactory> _queryFactoryMock = new Mock<IQueryFactory>();

        [Fact]
        public void Instance_Inherits_From_ServiceWithCommandFactory()
        {
            var type = typeof(ServiceWithCommandFactory);

            var service = ServiceWithCommandFactoryAndQueryFactory();

            Assert.IsAssignableFrom(type, service);
        }

        [Fact]
        public void GetQuery_Call_QueryFactory_CreateQuery()
        {
            var service = ServiceWithCommandFactoryAndQueryFactory();

            service.CallGetQuery();

            _queryFactoryMock.Verify(p => p.CreateQuery<Query<bool>>(), Times.Once);
        }


        private AwesomeServiceWithCommandFactoryAndQueryFactory ServiceWithCommandFactoryAndQueryFactory()
        {
            var commandFactoryMock = new Mock<ICommandFactory>();

            var service = new AwesomeServiceWithCommandFactoryAndQueryFactory(commandFactoryMock.Object, _queryFactoryMock.Object);
            return service;
        }
    }
}