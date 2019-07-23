using System.Collections.Generic;
using Altairis.AskMe.Data.Transfer.Objects;
using Olbrasoft.Querying;

namespace Altairis.AskMe.Data.Queries
{
    public class CategoriesListItemsQuery : Query<IEnumerable<CategoryListItemDto>>
    {
        public CategoriesListItemsQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}