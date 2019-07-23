using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            containerMock.Object.AddQuering();

            containerMock.Verify(mock => mock.Register(), Times.AtMostOnce);

        }
    }
}
