using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using Moq;
using NUnit.Framework;
using Olbrasoft.AskMe.Data.EntityFrameworkCore.QueryHandlers;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Querying;
using Olbrasoft.Pagination;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers
{
    public class PagedUnansweredQuestionsQueryHandlerTest
    {
        [Test]
        public void Instance_Is_QueryHandler_Of_PagedUnansweredQuestionsQuery_Comma_Question_Comma_IResultWithTotalCount_Of_UnansweredQuestionDto()
        {
            //Arrange
            var type =
                typeof(QueryHandler<PagedUnansweredQuestionsQuery, Question, IResultWithTotalCount<UnansweredQuestionDto>>);

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

            var handler = new PagedUnansweredQuestionsQueryHandler(contextMock.Object, projectorMock.Object);
            return handler;
        }
    }
}