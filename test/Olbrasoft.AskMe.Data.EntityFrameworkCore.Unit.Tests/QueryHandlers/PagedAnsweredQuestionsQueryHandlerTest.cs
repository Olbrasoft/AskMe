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
    public class PagedAnsweredQuestionsQueryHandlerTest
    {
        [Test]
        public void Instance_Inherits_From_DbQueryHandler_Of_PagedAnsweredQuestionsQuery_Comma_IResultWithTotalCount_Of_AnsweredQuestionDto_Comma_Question()
        {
            //Arrange
            var type =
                typeof(AskQueryHandler<PagedAnsweredQuestionsQuery, IResultWithTotalCount<QuestionDto>, Question>);

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
            var projectorMock = new Mock<IProjector>();

            var handler = new PagedAnsweredQuestionsQueryHandler(projectorMock.Object, askDbContextMock.Object);
            return handler;
        }
    }
}