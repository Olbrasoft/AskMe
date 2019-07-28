using System.Collections.Generic;
using X.PagedList;

namespace Olbrasoft.Paging.X.PagedList
{
    public class SimplePagedList<T> : BasePagedList<T>
    {
        public SimplePagedList(IEnumerable<T> subSet, int pageNumber, int pageSize, int totalItemCount) : base(pageNumber, pageSize, totalItemCount)
        {
            Subset.AddRange(subSet);
        }
    }
}