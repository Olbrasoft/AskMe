using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace Olbrasoft.AskMe.Business.DependencyInjection.Microsoft
{
    public class ServicesExtensionTest
    {
        [Fact]
        public void AddBusiness()
        {
            var servicesMock = new  Mock<IServiceCollection>();

            servicesMock.Object.AddBusiness();
         
            servicesMock.Verify(s=>s.Add(It.IsAny<ServiceDescriptor>()),Times.AtLeast(3));
        }
    }
}
