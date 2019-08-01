using Moq;
using Olbrasoft.Mapping;
using Xunit;

namespace Olbrasoft.Querying.Mapping
{
    public class QueryHandlerWithMapperTest
    {

        private Mock<IMapper> _mapperMock = new Mock<IMapper>();

        [Fact]
        public void Is_Abstract()
        {
            var type = typeof(QueryHandlerWithMapper<,>);

            var result = type.IsAbstract;

            Assert.True(result);
        }

        [Fact]
        public void Inherits_From_QueryHandler()
        {
            var baseType = typeof(QueryHandler<Query<bool>, bool>);

            var result = typeof(QueryHandlerWithMapper<Query<bool>, bool>).IsSubclassOf(baseType);

            Assert.True(result);
        }

        [Fact]
        public void AwesomeQueryHandlerWithMapper_Inherits_From_QueryHandlerWithMapper_Of_Query_Of_Bool_Comma_Bool()
        {
            var handler = AwesomeQueryHandlerWithMapper();

            Assert.IsAssignableFrom<QueryHandlerWithMapper<Query<bool>, bool>>(handler);
        }

        private AwesomeQueryHandlerWithMapper AwesomeQueryHandlerWithMapper()
        {
         
            var handler = new AwesomeQueryHandlerWithMapper(_mapperMock.Object);
            return handler;
        }


        [Fact]
        public void MapTo_Call_Mapper_Map()
        {
            var handler = AwesomeQueryHandlerWithMapper();

            handler.CallMapTo();

            _mapperMock.Verify(p=>p.MapTo<bool>(true),Times.Once);
        }

    }
}