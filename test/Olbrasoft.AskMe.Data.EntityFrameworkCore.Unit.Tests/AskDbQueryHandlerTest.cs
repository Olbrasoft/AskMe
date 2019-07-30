using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using Olbrasoft.Mapping;


namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.Unit.Tests
{
    public class AskDbQueryHandlerTest
    {
        [Test]
        public void Instance_Inherits_From_DbQueryHandler()
        {
            var contextMock = new Mock<AskDbContext>();
            var projectorMock= new Mock<IProjector>();

            var handler = new AwesomeQueryHandler(projectorMock.Object,contextMock.Object);

        }
    }
}
