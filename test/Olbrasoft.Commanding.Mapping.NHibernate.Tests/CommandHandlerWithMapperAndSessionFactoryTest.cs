using Moq;
using NHibernate;
using Olbrasoft.Mapping;
using Olbrasoft.Querying.Mapping;
using Xunit;

namespace Olbrasoft.Commanding.Mapping.NHibernate
{
    public class CommandHandlerWithMapperAndSessionFactoryTest
    {

        private readonly Mock<ISessionFactory> _factoryMock = new Mock<ISessionFactory>();

        [Fact]
        public void Is_Abstract()
        {
            var type = typeof(CommandHandlerWithMapperAndSessionFactory<Command>);

            var result = type.IsAbstract;

            Assert.True(result);
        }

        [Fact]
        public void Inherits_From_QueryHandlerWithMapper()
        {
            var baseType = typeof(CommandHandlerWithMapper<Command>);

            var type = typeof(CommandHandlerWithMapperAndSessionFactory<Command>);

            Assert.True(type.IsSubclassOf(baseType));
        }

        [Fact]
        public void AwesomeCommandHandlerWithMapperAndSessionFactory_Inherits_From_CommandHandlerWithMapperAndSessionFactory_Of_Command()
        {
            var handler = AwesomeCommandHandlerWithMapperAndSessionFactory();

            Assert.IsAssignableFrom<CommandHandlerWithMapperAndSessionFactory<Command>>(handler);
        }

        private AwesomeCommandHandlerWithMapperAndSessionFactory AwesomeCommandHandlerWithMapperAndSessionFactory()
        {
            var mapperMock = new Mock<IMapper>();

            var handler = new AwesomeCommandHandlerWithMapperAndSessionFactory(mapperMock.Object,_factoryMock.Object);
            return handler;
        }


        [Fact]
        public void Fill_Session_Call_FactorySession_OpenSession()
        {
            var handler = AwesomeCommandHandlerWithMapperAndSessionFactory();

            var session = handler.Session;

            _factoryMock.Verify(p=>p.OpenSession(),Times.Once);
        }

    }
}
