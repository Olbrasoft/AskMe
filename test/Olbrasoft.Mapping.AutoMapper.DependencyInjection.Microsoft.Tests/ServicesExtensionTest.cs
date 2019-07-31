using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace Olbrasoft.Mapping.AutoMapper.DependencyInjection.Microsoft
{
    public class ServicesExtensionTest
    {
        [Fact]
        public void AddMapping()
        {
            var servicesMock = new Mock<IServiceCollection>();

            servicesMock.Object.AddMapping();

            servicesMock.Verify(p => p.Add(It.IsAny<ServiceDescriptor>()), Times.AtLeast(2));
        }
    }
}