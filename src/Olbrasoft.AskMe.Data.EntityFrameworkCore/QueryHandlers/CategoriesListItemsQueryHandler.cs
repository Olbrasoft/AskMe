using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Mapping;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.QueryHandlers
{
    public class CategoriesListItemsQueryHandler : AskQueryHandler<CategoriesListItemsQuery, IEnumerable<CategoryListItemDto>, Category>
    {
        public override async Task<IEnumerable<CategoryListItemDto>> HandleAsync(CategoriesListItemsQuery query,
            CancellationToken token)
        {
            return await ProjectTo<CategoryListItemDto>(Entities().OrderBy(x => x.Name)).ToArrayAsync(token);
        }

        public CategoriesListItemsQueryHandler(IProjector projector, AskDbContext context) : base(projector, context)
        {
        }
    }
}