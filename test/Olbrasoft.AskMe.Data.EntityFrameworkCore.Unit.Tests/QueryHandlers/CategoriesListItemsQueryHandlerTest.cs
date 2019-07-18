using System.Collections.Generic;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using Moq;
using NUnit.Framework;
using Olbrasoft.AskMe.Data.EntityFrameworkCore.QueryHandlers;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Querying;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers
{
    public class CategoriesListItemsQueryHandlerTest
    {
        [Test]
        public void Instance_Is_QueryHandler_Of_CategoriesListItemsQuery_Comma_Category_Comma_IEnumerable_Of_CategoryListItemDto()
        {
            //Arrange
            var type = typeof(QueryHandler<CategoriesListItemsQuery, Category, IEnumerable<CategoryListItemDto>>);

            //Act
            var handler = CategoriesListItemsQueryHandler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        [Test]
        public void HandleAsync_Returns_Task_Of_IEnumerable_Of_CategoryListItemDto()
        {
            //Arrange
            var handler = CategoriesListItemsQueryHandler();

            var dispatcherMock = new Mock<IQueryDispatcher>();
            var query = new CategoriesListItemsQuery(dispatcherMock.Object);
            
            //Act
            var result = handler.HandleAsync(query);

            //Assert
            Assert.IsInstanceOf<Task<IEnumerable<CategoryListItemDto>>>(result);
        }

        private static CategoriesListItemsQueryHandler CategoriesListItemsQueryHandler()
        {
            var contextMock = new Mock<AskDbContext>();
            var projectorMock = new Mock<IProjection>();

            var handler = new CategoriesListItemsQueryHandler(contextMock.Object, projectorMock.Object);
            return handler;
        }
    }
}