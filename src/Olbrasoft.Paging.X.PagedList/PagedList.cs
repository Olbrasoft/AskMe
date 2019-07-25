using System.Collections.Generic;
using X.PagedList;

namespace Olbrasoft.Paging.X.PagedList
{
    public class PagedList<T> : BasePagedList<T>, IPagedList<T>
    {
        public PagedList(IEnumerable<T> subSet, int pageNumber, int pageSize, int totalItemCount) : base(pageNumber, pageSize, totalItemCount)
        {
            Subset.AddRange(subSet);
        }
    }
}