using System;

namespace Olbrasoft.Paging
{
    public static class PageInfoExtension
    {
        public static int CalculateSkip(this IPageInfo pageInfo)
        {
            if (pageInfo == null) throw new ArgumentNullException(nameof(pageInfo));

            return (pageInfo.NumberOfSelectedPage - 1) * pageInfo.PageSize;
        }
    }
};