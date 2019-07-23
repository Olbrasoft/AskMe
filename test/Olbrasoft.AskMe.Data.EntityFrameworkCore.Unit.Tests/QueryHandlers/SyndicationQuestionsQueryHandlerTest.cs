using System.Collections.Generic;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using Moq;
using NUnit.Framework;
using Olbrasoft.AskMe.Data.EntityFrameworkCore.QueryHandlers;
using Olbrasoft.Mapping;
using Olbrasoft.Querying;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers
{
    public class SyndicationQuestionsQueryHandlerTest
    {
        [Test]
        public void Instance_Is_QueryHandler_Of_SyndicationQuestionsQuery_Comma_Question_Comma_IEnumerable_Of_SyndicationQuestionDto()
        {
            //Arrange
            var type = typeof(AskQueryHandler<SyndicationQuestionsQuery,  IEnumerable<SyndicationQuestionDto>,Question>);

            //Act
            var handler = SyndicationQuestionsQueryHandler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        [Test]
        public void HandleAsync_Return_Task_Of_IEnumerable_Of_SyndicationQuestionDto()
        {
            //Arrange
            var handler = SyndicationQuestionsQueryHandler();

            var dispatcherMock = new Mock<IQueryDispatcher>();
            var query = new SyndicationQuestionsQuery(dispatcherMock.Object);


            //Act
            var result = handler.HandleAsync(query);

            //Assert
            Assert.IsInstanceOf<Task<IEnumerable<SyndicationQuestionDto>>>(result);

        }

        private static SyndicationQuestionsQueryHandler SyndicationQuestionsQueryHandler()
        {
            var contextMock = new Mock<AskDbContext>();
            var projectorMock = new Mock<IProjection>();

            var handler = new SyndicationQuestionsQueryHandler(projectorMock.Object, contextMock.Object);
            return handler;
        }
    }
}