using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.QueryHandlers
{
    public class CategoriesListItemsQueryHandler : QueryHandler<CategoriesListItemsQuery, Category,
            IEnumerable<CategoryListItemDto>>
    {
        public CategoriesListItemsQueryHandler(AskDbContext context, IProjection projector) : base(context, projector)
        {
        }

        public override async Task<IEnumerable<CategoryListItemDto>> HandleAsync(CategoriesListItemsQuery query,
            CancellationToken token)
        {
            return await ProjectTo<CategoryListItemDto>(Source.OrderBy(x => x.Name)).ToArrayAsync(token);
        }
    }
}