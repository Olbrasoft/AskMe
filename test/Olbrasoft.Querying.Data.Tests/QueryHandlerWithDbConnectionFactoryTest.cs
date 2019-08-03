using Moq;
using Olbrasoft.Data;
using System;
using Xunit;

namespace Olbrasoft.Querying.Data
{
    public class QueryHandlerWithDbConnectionFactoryTest
    {
        private readonly Mock<IDbConnectionFactory> _factoryMock = new Mock<IDbConnectionFactory>();

        [Fact]
        public void Is_Abstract()
        {
            var type = QueryHandlerType();

            var result = type.IsAbstract;

            Assert.True(result);
        }

        private static Type QueryHandlerType()
        {
            var type = typeof(QueryHandlerWithDbConnectionFactory<Query<bool>, bool>);
            return type;
        }

        [Fact]
        public void Inherits_From_QueryHandler()
        {
            var baseType = typeof(QueryHandler<Query<bool>, bool>);

            var type = QueryHandlerType();

            var result = type.IsSubclassOf(baseType);

            Assert.True(result);
        }

        [Fact]
        public void AwesomeQueryHandlerWithDbConnectionFactory_Inherits_From_QueryHandlerWithDbConnectionFactory_Of_Query_Of_Bool_Comma_Bool()
        {
            var handler = AwesomeQueryHandlerWithDbConnectionFactory();

            Assert.IsAssignableFrom<QueryHandlerWithDbConnectionFactory<Query<bool>, bool>>(handler);
        }

        [Fact]
        public void GetConnection_Call_Factory_OpenConnection()
        {
            var handler = AwesomeQueryHandlerWithDbConnectionFactory();

            handler.CallGetConnection();

            _factoryMock.Verify(p => p.OpenConnection(), Times.Once);
        }

        private AwesomeQueryHandlerWithDbConnectionFactory AwesomeQueryHandlerWithDbConnectionFactory()
        {
            var handler = new AwesomeQueryHandlerWithDbConnectionFactory(_factoryMock.Object);
            return handler;
        }
    }
}