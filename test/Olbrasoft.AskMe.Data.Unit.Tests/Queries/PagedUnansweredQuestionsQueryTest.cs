using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using Moq;
using NUnit.Framework;
using Olbrasoft.Pagination;
using Olbrasoft.Querying;

namespace Olbrasoft.AskMe.Data.Unit.Tests.Queries
{
    public class PagedUnansweredQuestionsQueryTest
    {
        [Test]
        public void Instance_Is_Query_Of_IResultWithTotalCount_Of_UnansweredQuestionDto()
        {
            //Arrange
            var type = typeof(Query<IResultWithTotalCount<UnansweredQuestionDto>>);

            //Act
            var query = PagedUnansweredQuestionQuery();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Paging_Is_IPageInfo()
        {
            //Arrange
            var type = typeof(IPageInfo);
            var query = PagedUnansweredQuestionQuery();

            //Act
            query.Paging = new PageInfo();

            //Assert
            Assert.IsInstanceOf(type, query.Paging);
        }

        private static PagedUnansweredQuestionsQuery PagedUnansweredQuestionQuery()
        {
            var dispatcherMock = new Mock<IQueryDispatcher>();
            var query = new PagedUnansweredQuestionsQuery(dispatcherMock.Object);
            return query;
        }
    }
}