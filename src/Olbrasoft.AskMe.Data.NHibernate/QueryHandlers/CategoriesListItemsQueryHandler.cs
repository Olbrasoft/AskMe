using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using NHibernate;
using Olbrasoft.Mapping;
using Olbrasoft.Querying.Mapping.NHibernate;

namespace Olbrasoft.AskMe.Data.NHibernate.QueryHandlers
{
    public class CategoriesListItemsQueryHandler : QueryHandlerWithMapperAndSessionFactory<CategoriesListItemsQuery, IEnumerable<CategoryListItemDto>>
    {
        public CategoriesListItemsQueryHandler(IMapper mapper, ISessionFactory factory) : base(mapper, factory)
        {
        }

        public override async Task<IEnumerable<CategoryListItemDto>> HandleAsync(CategoriesListItemsQuery query, CancellationToken token)
        {
            var categories = await Session.QueryOver<Category>().OrderBy(p => p.Name).Asc.ListAsync(token);

            var result = MapTo<IEnumerable<CategoryListItemDto>>(categories);

            return result;
        }
    }
}