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
    public class PagedAnsweredQuestionsQueryHandlerTest
    {
        [Test]
        public void Instance_Is_QueryHandler_Of_PagedAnsweredQuestionsQuery_Comma_Question_Comma_IResultWithTotalCount_Of_AnsweredQuestionDto()
        {
            //Arrange
            var type =
                typeof(QueryHandler<PagedAnsweredQuestionsQuery, Question, IResultWithTotalCount<QuestionDto>>);

            //Act
            var handler = PagedAnsweredQuestionsQueryHandler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        [Test]
        public void HandleAsync_Returns_Task_Of_IResultWithTotalCount_Of_AnsweredQuestionDto()
        {
            //Arrange
            var handler = PagedAnsweredQuestionsQueryHandler();
            var dispatcherMock = new Mock<IQueryDispatcher>();
            var query = new PagedAnsweredQuestionsQuery(dispatcherMock.Object);

            //Act
            var result = handler.HandleAsync(query);

            //Assert
            Assert.IsInstanceOf<Task<IResultWithTotalCount<QuestionDto>>>(result);
        }

        private static PagedAnsweredQuestionsQueryHandler PagedAnsweredQuestionsQueryHandler()
        {
            var askDbContextMock = new Mock<AskDbContext>();
            var projectorMock = new Mock<IProjection>();

            var handler = new PagedAnsweredQuestionsQueryHandler(askDbContextMock.Object, projectorMock.Object);
            return handler;
        }
    }
}