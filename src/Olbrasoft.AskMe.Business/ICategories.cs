using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Transfer.Objects;

namespace Olbrasoft.AskMe.Business
{
    public interface ICategories
    {
        Task<IEnumerable<CategoryListItemDto>> GetAsync(CancellationToken token = default);
    }
}