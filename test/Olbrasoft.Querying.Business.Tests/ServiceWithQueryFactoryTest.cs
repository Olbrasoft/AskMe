using Moq;
using Xunit;

namespace Olbrasoft.Querying.Business
{
    public class ServiceWithQueryFactoryTest
    {
        [Fact]
        public void GetQuery_Call_Factory_CreateQuery()
        {

            var factoryMock = new Mock<IQueryFactory>();
            var service = new AwesomeServiceWithQueryFactory(factoryMock.Object);

            service.CallGetQuery();

            factoryMock.Verify(p=>p.CreateQuery<Query<bool>>(),Times.Once);
        }
    }
}


