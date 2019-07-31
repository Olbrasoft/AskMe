using Microsoft.EntityFrameworkCore;
using Moq;
using Olbrasoft.Mapping;
using Xunit;

namespace Olbrasoft.Commanding.Mapping.EntityFrameworkCore
{
    public class CommandHandlerWithMapperAndDbContextTest
    {
        [Fact]
        public void Is_Abstract()
        {
            var type = typeof(CommandHandlerWithMapperAndDbContext<,>);

            Assert.True(type.IsAbstract);
        }

        [Fact]
        public void Inherits_From_CommandHandlerWithMapper()
        {
            var baseType = typeof(CommandHandlerWithMapper<Command>);

            var type = typeof(CommandHandlerWithMapperAndDbContext<Command,DbContext>);

            Assert.True(type.IsSubclassOf(baseType));
           
        }

        [Fact]
        public void Constructor_Initialize_Protected_Context()
        {

            var mapperMock = new Mock<IMapper>();
            var contextMock = new Mock<DbContext>();

            var handler = new AwesomeCommandHandlerWithMapperAndDbContext(mapperMock.Object, contextMock.Object);

            Assert.Equal(contextMock.Object,handler.Context);
        }


    }
}