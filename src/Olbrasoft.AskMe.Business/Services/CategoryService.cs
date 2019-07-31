using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using Olbrasoft.Querying;
using Olbrasoft.Querying.Business;

namespace Olbrasoft.AskMe.Business.Services
{
    public class CategoryService : ServiceWithQueryFactory, ICategories
    {
        public CategoryService(IQueryFactory factory) : base(factory)
        {
        }

        public Task<IEnumerable<CategoryListItemDto>> GetAsync(CancellationToken token = default)
        {
            var query = GetQuery<CategoriesListItemsQuery>();

            return query.ExecuteAsync(token);
        }
    }
}