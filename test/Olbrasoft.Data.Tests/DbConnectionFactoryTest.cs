using System.Data;
using Moq;
using Xunit;

namespace Olbrasoft.Data
{
    public class DbConnectionFactoryTest
    {
        private readonly Mock<IDbConnection> _connectionMock = new Mock<IDbConnection>();

        [Fact]
        public void Instance_Implement_Interface_IDbConnectionFactory()
        {
            var type = typeof(IDbConnectionFactory);
            var factory = new DbConnectionFactory(() => _connectionMock.Object);

            Assert.IsAssignableFrom(type, factory);
        }


        [Fact]
        public void CreateConnection_Return_Same_Object_As_Function_BuildConnection()
        {
            var factory = new DbConnectionFactory(() => _connectionMock.Object);

            var result = factory.CreateConnection();

            Assert.Equal(_connectionMock.Object,result);

        }

        [Fact]
        public void OpenConnection_Call_Connection_Open()
        {
            var factory = new DbConnectionFactory(() => _connectionMock.Object);
            var result = factory.OpenConnection();

            _connectionMock.Verify(p=>p.Open(),Times.Once);
        }


    }
}