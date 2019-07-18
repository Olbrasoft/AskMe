using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;
using Olbrasoft.Pagination;

namespace Olbrasoft.AskMe.Data.Unit.Tests.Queries
{
    public class PagedAnsweredQuestionsQueryTest
    {
        [Test]
        public void Instance_Is_Query_Of_IResultWithTotalCount_Of_AnsweredQuestionDto()
        {
            //Arrange
            var type = typeof(Query<IResultWithTotalCount<QuestionDto>>);

            //Act
            var query = PagedAnsweredQuestionsQuery();

            //Assert
            Assert.IsInstanceOf(type,query);
        }


        [Test]
        public void Paging_Is_IPageInfo()
        {
            //Arrange
            var query = PagedAnsweredQuestionsQuery();
            query.Paging = new PageInfo();

            //Act
            var paging = query.Paging;

            //Assert
            Assert.IsInstanceOf<IPageInfo>(paging);

        }
        

        private static PagedAnsweredQuestionsQuery PagedAnsweredQuestionsQuery()
        {
            var queryDispatcherMock = new Mock<IQueryDispatcher>();
            var query = new PagedAnsweredQuestionsQuery(queryDispatcherMock.Object);
            return query;
        }
    }
}
