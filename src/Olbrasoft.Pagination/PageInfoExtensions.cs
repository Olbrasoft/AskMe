using System;

namespace Olbrasoft.Pagination
{
    public static class PageInfoExtensions
    {
        public static int CalculateSkip(this IPageInfo pageInfo)
        {
            if (pageInfo == null) throw new ArgumentNullException(nameof(pageInfo));

            return (pageInfo.NumberOfSelectedPage - 1) * pageInfo.PageSize;
        }
    }
};