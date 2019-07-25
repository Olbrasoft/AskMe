using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using Moq;
using NUnit.Framework;
using Olbrasoft.AskMe.Data.EntityFrameworkCore.QueryHandlers;
using Olbrasoft.Mapping;
using Olbrasoft.Paging;
using Olbrasoft.Querying;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers
{
    public class PagedUnansweredQuestionsQueryHandlerTest
    {
        [Test]
        public void Instance_Inherits_From_AskDbQueryHandler_Of_PagedUnansweredQuestionsQuery_Comma_IResultWithTotalCount_Of_UnansweredQuestionDto_Comma_Question()
        {
            //Arrange
            var type =
                typeof(AskQueryHandler<PagedUnansweredQuestionsQuery, IResultWithTotalCount<UnansweredQuestionDto>,Question>);

            //Act
            var handler = PagedUnansweredQuestionsQueryHandler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        [Test]
        public void HandleAsync_Returns_Task_Of_IResultWithTotalCount_Of_AnsweredQuestionDto()
        {
            //Arrange
            var handler = PagedUnansweredQuestionsQueryHandler();
            var dispatcherMock = new Mock<IQueryDispatcher>();
            var query = new PagedUnansweredQuestionsQuery(dispatcherMock.Object);

            //Act
            var result = handler.HandleAsync(query);

            //Assert
            Assert.IsInstanceOf<Task<IResultWithTotalCount<UnansweredQuestionDto>>>(result);
        }

        private static PagedUnansweredQuestionsQueryHandler PagedUnansweredQuestionsQueryHandler()
        {
            var contextMock = new Mock<AskDbContext>();
            var projectorMock = new Mock<IProjection>();

            var handler = new PagedUnansweredQuestionsQueryHandler(projectorMock.Object,contextMock.Object);
            return handler;
        }
    }
}