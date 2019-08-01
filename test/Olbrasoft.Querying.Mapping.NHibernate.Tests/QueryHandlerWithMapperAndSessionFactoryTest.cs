using Moq;
using NHibernate;
using Olbrasoft.Mapping;
using Xunit;

namespace Olbrasoft.Querying.Mapping.NHibernate
{
    public class QueryHandlerWithMapperAndSessionFactoryTest
    {

        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        private readonly Mock<ISessionFactory> _factoryMock = new Mock<ISessionFactory>();

        [Fact]
        public void Is_Abstract()
        {
            var type = typeof(QueryHandlerWithMapperAndSessionFactory<,>);

            var result = type.IsAbstract;

            Assert.True(result);

        }

        [Fact]
        public void Inherits_From_QueryHandlerWithMapper()
        {
            var baseType = typeof(QueryHandlerWithMapper<Query<bool>, bool>);


            Assert.True(typeof(QueryHandlerWithMapperAndSessionFactory<Query<bool>,bool>).IsSubclassOf(baseType));

        }

        [Fact]
        public void AwesomeQueryHandlerWithMapperAndSessionFactory_Inherits_From_QueryHandlerWithMapperAndSessionFactory_Of_Query_Of_Bool_Comma_Bool()
        {
            var handler = AwesomeQueryHandlerWithMapperAndSessionFactory();

            Assert.IsAssignableFrom<QueryHandlerWithMapperAndSessionFactory<Query<bool>, bool>>(handler);
        }

        private AwesomeQueryHandlerWithMapperAndSessionFactory AwesomeQueryHandlerWithMapperAndSessionFactory()
        {
            var handler = new AwesomeQueryHandlerWithMapperAndSessionFactory(_mapperMock.Object,_factoryMock.Object);
            return handler;
        }

        [Fact]
        public void Fill_Session_Call_Factory_OpenSession()
        {
            var handler = AwesomeQueryHandlerWithMapperAndSessionFactory();
            var session =  handler.Session;

            _factoryMock.Verify(p=>p.OpenSession(),Times.Once);

        }

    }
}
