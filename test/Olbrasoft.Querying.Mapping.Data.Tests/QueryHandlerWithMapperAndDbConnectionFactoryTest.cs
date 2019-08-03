using Moq;
using Olbrasoft.Data;
using Olbrasoft.Mapping;
using Xunit;

namespace Olbrasoft.Querying.Mapping.Data
{
    public class QueryHandlerWithMapperAndDbConnectionFactoryTest
    {
        private readonly Mock<IDbConnectionFactory> _factoryMock = new Mock<IDbConnectionFactory>();

        [Fact]
        public void Is_Abstract()
        {
            var type = typeof(QueryHandlerWithMapperAndDbConnectionFactory<,>);

            var result = type.IsAbstract;

            Assert.True(result);
        }

        [Fact]
        public void Inherits_From_QueryHandlerWithMapper()
        {
            var baseType = typeof(QueryHandlerWithMapper<Query<bool>, bool>);

            var type = typeof(QueryHandlerWithMapperAndDbConnectionFactory<Query<bool>, bool>);

            Assert.True(type.IsSubclassOf(baseType));
        }

        [Fact]
        public void
            AwesomeQueryHandlerWithMapperAndConnectionFactory_Inherits_From_QueryHandlerWithMapperAndConnectionFactory_Of_Query_Of_Bool_Comma_Bool()
        {
            var handler = AwesomeQueryHandlerWithMapperAndConnectionFactory();

            Assert.IsAssignableFrom<QueryHandlerWithMapperAndDbConnectionFactory<Query<bool>, bool>>(handler);
        }

        [Fact]
        public void GetConnection_Call_Factory_OpenConnection()
        {
            var handler = AwesomeQueryHandlerWithMapperAndConnectionFactory();

            handler.CallGetConnection();

            _factoryMock.Verify(p => p.OpenConnection(), Times.Once);
        }

        private AwesomeQueryHandlerWithMapperAndDbConnectionFactory AwesomeQueryHandlerWithMapperAndConnectionFactory()
        {
            var mapperMock = new Mock<IMapper>();

            var handler = new AwesomeQueryHandlerWithMapperAndDbConnectionFactory(mapperMock.Object, _factoryMock.Object);
            return handler;
        }
    }
}