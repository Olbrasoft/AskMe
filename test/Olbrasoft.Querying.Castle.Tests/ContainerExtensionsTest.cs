using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel;
using Castle.Windsor;
using Moq;
using Xunit;

namespace Olbrasoft.Querying.Castle
{
    public class ContainerExtensionsTest
    {
        [Fact]
        public void AddQuerying()
        {
            var containerMock = new Mock<IWindsorContainer>();
            var mockKernel = new Mock<IKernel>();

            containerMock.Setup(p => p.Kernel).Returns(mockKernel.Object);
            containerMock.Object.AddQuering();

            containerMock.Verify(mock => mock.Register(), Times.AtMostOnce);

        }

        [Fact]
        public void StrongNameAssembly()
        {
            var assemblyName = typeof(Query<>).Assembly.GetName().Name;

            Assert.True(assemblyName=="Olbrasoft.Querying");

        }

      
    }
}
