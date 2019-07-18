using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using Olbrasoft.Data.Commanding;
using Olbrasoft.Data.Querying;

namespace Olbrasoft.AskMe.Business.Services
{
    public class CategoryService : Service, ICategories
    {
        public CategoryService(ICommandFactory commandFactory, IQueryFactory queryFactory) : base(commandFactory, queryFactory)
        {
        }

        public Task<IEnumerable<CategoryListItemDto>> GetAsync(CancellationToken cancellationToken = default)
        {
            var query = QueryFactory.Get<CategoriesListItemsQuery>();

            return query.ExecuteAsync(cancellationToken);
        }
    }
}