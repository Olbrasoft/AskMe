using System.Collections.Generic;
using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;

namespace Olbrasoft.AskMe.Data.Unit.Tests.Queries
{
    public class CategoriesListItemsQueryTest
    {
        [Test]
        public void Instance_Is_Query_Of_IEnumerable_CategoryListItemDto()
        {
            //Arrange
            var type = typeof(Query<IEnumerable<CategoryListItemDto>>);

            //Act
            var query = CategoriesListItemsQuery();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        private static CategoriesListItemsQuery CategoriesListItemsQuery()
        {
            var queryDispatcherMock = new Mock<IQueryDispatcher>();

            var query = new CategoriesListItemsQuery(queryDispatcherMock.Object);
            return query;
        }
    }
}