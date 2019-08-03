using System.Collections.Generic;
using System.Linq;
using System.Text;
using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using Moq;
using Olbrasoft.Data;
using Olbrasoft.Mapping;
using Olbrasoft.Paging;
using Olbrasoft.Querying.Mapping.Data;
using Xunit;

namespace Olbrasoft.AskMe.Data.Dapper.QueryHandlers
{
    public class PagedAnsweredQuestionsQueryHandlerTest
    {
        [Fact]
        public void Instance_Inherits_From_QueryHandlerWithMapperAndConnectionFactory()
        {
            var type = typeof(QueryHandlerWithMapperAndDbConnectionFactory<PagedAnsweredQuestionsQuery, IResultWithTotalCount<QuestionDto>>);


            var handler = PagedAnsweredQuestionsQueryHandler();

            Assert.IsAssignableFrom(type,handler);
        }

        private static PagedAnsweredQuestionsQueryHandler PagedAnsweredQuestionsQueryHandler()
        {

            var mapperMock = new Mock<IMapper>();
            var factoryMock = new Mock<IDbConnectionFactory>();

            var handler = new PagedAnsweredQuestionsQueryHandler(mapperMock.Object,factoryMock.Object);
            return handler;
        }
    }
}
