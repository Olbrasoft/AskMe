using Moq;
using Olbrasoft.Mapping;
using Xunit;

namespace Olbrasoft.Commanding.Mapping
{
    public class CommandHandlerWithMapperTest
    {
        [Fact]
        public void Inherits_From_CommandHandler()
        {
            var baseType = typeof(CommandHandler<Command>);
            var type = typeof(CommandHandlerWithMapper<Command>);
            Assert.True(type.IsSubclassOf(baseType));
        }


        [Fact]
        public void MapTo_Call_Mapper_MapTo()
        {
            var mapperMock = new Mock<IMapper>();

            var handler = new AwesomeCommandHandlerWithMapper(mapperMock.Object);

            handler.MapTo<bool>(true);

            mapperMock.Verify(p=>p.MapTo<bool>(true),Times.Once);

        }

    }
}