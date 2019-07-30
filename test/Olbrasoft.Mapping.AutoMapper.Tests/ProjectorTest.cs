using AutoMapper;
using Moq;
using Xunit;

namespace Olbrasoft.Mapping.AutoMapper
{
    public class ProjectorTest
    {
        [Fact]
        public void Instance_Implement_Interface_IProjection()
        {
            var providerMOck = new Mock<IConfigurationProvider>();

            var projector = new Projector(providerMOck.Object);

            Assert.IsAssignableFrom<IProjector>(projector);
        }



    }
}