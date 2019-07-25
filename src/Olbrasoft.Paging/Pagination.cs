using System;

namespace Olbrasoft.Paging
{
    public class Pagination : BasePagination
    {
        public Func<int> CountAllItems { get; }

        public Pagination(IPageInfo pageInfo, Func<int> countAllItems) : base(pageInfo)
        {
            CountAllItems = countAllItems;
        }

        public override int CountWithOutPaging()
        {
            return CountAllItems();
        }
    }
}