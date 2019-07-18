using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;
using X.PagedList.Mvc.Common;

namespace Olbrasoft.Pagination.Mvc
{
    [HtmlTargetElement("pager")]
    public class PagerTagHelper : TagHelper
    {
        #region list

        private const string ListAttributeName = "list";

        [HtmlAttributeName(ListAttributeName)]
        public IPagedList List { get; set; }

        #endregion list

        #region asp-route

        private const string RouteValuesDictionaryName = "asp-all-route-data";

        private const string RouteValuesPrefix = "asp-route-";

        [HtmlAttributeName(RouteValuesDictionaryName, DictionaryAttributePrefix = RouteValuesPrefix)]
        public IDictionary<string, string> RouteValues { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        #endregion asp-route

        #region asp-action

        private const string ActionAttributeName = "asp-action";

        [HtmlAttributeName(ActionAttributeName)]
        public string AspAction { get; set; }

        #endregion asp-action

        #region asp-controller

        private const string ControllerAttributeName = "asp-controller";

        [HtmlAttributeName(ControllerAttributeName)]
        public string AspController { get; set; }

        #endregion asp-controller

        #region asp-area

        private const string AreaAttributeName = "asp-area";

        [HtmlAttributeName(AreaAttributeName)]
        public string AspArea { get; set; }

        #endregion asp-area

        #region options

        private const string OptionsAttributeName = "options";

        [HtmlAttributeName(OptionsAttributeName)]
        public PagedListRenderOptionsBase Options { get; set; }

        #endregion options

        #region param-page-number

        private const string ParamPageNumberAttributeName = "param-page-number";

        [HtmlAttributeName(ParamPageNumberAttributeName)]
        public string ParamPageNumber { get; set; } = "page";

        #endregion param-page-number

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        private readonly IUrlHelperFactory _urlHelperFactory;

        public PagerTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }

        private string GeneratePageUrl(int pageNumber, IUrlHelper urlHelper)
        {
            var routeValues = new RouteValueDictionary(RouteValues);

            if (ParamPageNumber != null)
            {
                routeValues[ParamPageNumber] = pageNumber;
            }

            // Unconditionally replace any value from asp-route-area.
            if (AspArea != null)
            {
                routeValues["area"] = AspArea;
            }

            return urlHelper.Action(AspAction, AspController, routeValues);
        }

        private TagBuilder WrapInListItem(string text)
        {
            var li = new TagBuilder("li");
            li.InnerHtml.AppendHtml(text);

            return li;
        }

        private static TagBuilder WrapInListItem(TagBuilder inner, params string[] classes)
        {
            var li = new TagBuilder("li");
            foreach (var @class in classes)
            {
                li.AddCssClass(@class);
            }

            li.InnerHtml.AppendHtml(inner);

            return li;
        }

        private TagBuilder First(IUrlHelper urlHelper)
        {
            const int targetPageNumber = 1;
            var first = new TagBuilder("a");
            foreach (var @class in Options.LiElementClasses)
            {
                first.AddCssClass(@class);
            }

            first.InnerHtml.AppendHtml(string.Format(Options.LinkToFirstPageFormat, targetPageNumber));

            if (List.IsFirstPage)
            {
                return WrapInListItem(first, "PagedList-skipToFirst", "disabled");
            }

            first.Attributes["href"] = GeneratePageUrl(targetPageNumber, urlHelper);
            return WrapInListItem(first, "PagedList-skipToFirst");
        }

        private TagBuilder Previous(IUrlHelper urlHelper)
        {
            var targetPageNumber = List.PageNumber - 1;
            var previous = new TagBuilder("a");

            foreach (var @class in Options.LiElementClasses)
            {
                previous.AddCssClass(@class);
            }

            previous.InnerHtml.AppendHtml(string.Format(Options.LinkToPreviousPageFormat, targetPageNumber));
            previous.Attributes["rel"] = "prev";

            if (!List.HasPreviousPage)
            {
                return WrapInListItem(previous, "PagedList-skipToPrevious", "disabled");
            }

            previous.Attributes["href"] = GeneratePageUrl(targetPageNumber, urlHelper);

            return WrapInListItem(previous, "PagedList-skipToPrevious");
        }

        private TagBuilder Page(int i, IUrlHelper urlHelper)
        {
            var format = Options.FunctionToDisplayEachPageNumber
                ?? (pageNumber => string.Format(Options.LinkToIndividualPageFormat, pageNumber));
            var targetPageNumber = i;
            var page = new TagBuilder("a");
            foreach (var @class in Options.LiElementClasses)
            {
                page.AddCssClass(@class);
            }

            page.InnerHtml.AppendHtml(format(targetPageNumber));

            if (i == List.PageNumber)
                return WrapInListItem(page, "active");

            page.Attributes["href"] = GeneratePageUrl(targetPageNumber, urlHelper);
            return WrapInListItem(page);
        }

        private TagBuilder Next(IUrlHelper urlHelper)
        {
            var targetPageNumber = List.PageNumber + 1;
            var next = new TagBuilder("a");
            foreach (var @class in Options.LiElementClasses)
            {
                next.AddCssClass(@class);
            }

            next.InnerHtml.AppendHtml(string.Format(Options.LinkToNextPageFormat, targetPageNumber));
            next.Attributes["rel"] = "next";

            if (!List.HasNextPage)
            {
                return WrapInListItem(next, "PagedList-skipToNext", "disabled");
            }

            next.Attributes["href"] = GeneratePageUrl(targetPageNumber, urlHelper);
            return WrapInListItem(next, "PagedList-skipToNext");
        }

        private TagBuilder Last(IUrlHelper urlHelper)
        {
            var targetPageNumber = List.PageCount;
            var last = new TagBuilder("a");
            foreach (var @class in Options.LiElementClasses)
            {
                last.AddCssClass(@class);
            }

            last.InnerHtml.AppendHtml(string.Format(Options.LinkToLastPageFormat, targetPageNumber));

            if (List.IsLastPage)
            {
                return WrapInListItem(last, "PagedList-skipToLast", "disabled");
            }

            last.Attributes["href"] = GeneratePageUrl(targetPageNumber, urlHelper);
            return WrapInListItem(last, "PagedList-skipToLast");
        }

        private TagBuilder PageCountAndLocationText()
        {
            var text = new TagBuilder("a");
            text.InnerHtml.AppendHtml(string.Format(Options.PageCountAndCurrentLocationFormat, List.PageNumber, List.PageCount));

            return WrapInListItem(text, "PagedList-pageCountAndLocation", "disabled");
        }

        private TagBuilder ItemSliceAndTotalText()
        {
            var text = new TagBuilder("a");
            text.InnerHtml.AppendHtml(string.Format(Options.ItemSliceAndTotalFormat, List.FirstItemOnPage, List.LastItemOnPage, List.TotalItemCount));

            return WrapInListItem(text, "PagedList-pageCountAndLocation", "disabled");
        }

        private TagBuilder Ellipses()
        {
            var a = new TagBuilder("a");
            a.InnerHtml.AppendHtml(Options.EllipsesFormat);

            return WrapInListItem(a, "PagedList-ellipses", "disabled");
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (List == null)
            {
                return;
            }

            if (Options == null)
            {
                Options = new PagedListRenderOptions();
            }

            var urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);

            var listItemLinks = new List<TagBuilder>();

            //calculate start and end of range of page numbers
            var firstPageToDisplay = 1;
            var lastPageToDisplay = List.PageCount;
            var pageNumbersToDisplay = lastPageToDisplay;
            if (Options.MaximumPageNumbersToDisplay.HasValue && List.PageCount > Options.MaximumPageNumbersToDisplay)
            {
                // cannot fit all pages into pager
                var maxPageNumbersToDisplay = Options.MaximumPageNumbersToDisplay.Value;
                firstPageToDisplay = List.PageNumber - maxPageNumbersToDisplay / 2;
                if (firstPageToDisplay < 1)
                {
                    firstPageToDisplay = 1;
                }

                pageNumbersToDisplay = maxPageNumbersToDisplay;
                lastPageToDisplay = firstPageToDisplay + pageNumbersToDisplay - 1;
                if (lastPageToDisplay > List.PageCount)
                {
                    lastPageToDisplay = List.PageCount;
                    firstPageToDisplay = List.PageCount - maxPageNumbersToDisplay + 1;
                }
            }

            //first
            if (Options.DisplayLinkToFirstPage == PagedListDisplayMode.Always || (Options.DisplayLinkToFirstPage == PagedListDisplayMode.IfNeeded && firstPageToDisplay > 1))
            {
                listItemLinks.Add(First(urlHelper));
            }

            //previous
            if (Options.DisplayLinkToPreviousPage == PagedListDisplayMode.Always || (Options.DisplayLinkToPreviousPage == PagedListDisplayMode.IfNeeded && !List.IsFirstPage))
            {
                listItemLinks.Add(Previous(urlHelper));
            }

            //text
            if (Options.DisplayPageCountAndCurrentLocation)
            {
                listItemLinks.Add(PageCountAndLocationText());
            }

            //text
            if (Options.DisplayItemSliceAndTotal)
            {
                listItemLinks.Add(ItemSliceAndTotalText());
            }

            //page
            if (Options.DisplayLinkToIndividualPages)
            {
                //if there are previous page numbers not displayed, show an ellipsis
                if (Options.DisplayEllipsesWhenNotShowingAllPageNumbers && firstPageToDisplay > 1)
                {
                    listItemLinks.Add(Ellipses());
                }

                for (int i = firstPageToDisplay; i <= lastPageToDisplay; i++)
                {
                    //show delimiter between page numbers
                    if (i > firstPageToDisplay && !string.IsNullOrWhiteSpace(Options.DelimiterBetweenPageNumbers))
                    {
                        listItemLinks.Add(WrapInListItem(Options.DelimiterBetweenPageNumbers));
                    }

                    //show page number link
                    listItemLinks.Add(Page(i, urlHelper));
                }

                //if there are subsequent page numbers not displayed, show an ellipsis
                if (Options.DisplayEllipsesWhenNotShowingAllPageNumbers && (firstPageToDisplay + pageNumbersToDisplay - 1) < List.PageCount)
                {
                    listItemLinks.Add(Ellipses());
                }
            }

            //next
            if (Options.DisplayLinkToNextPage == PagedListDisplayMode.Always || (Options.DisplayLinkToNextPage == PagedListDisplayMode.IfNeeded && !List.IsLastPage))
            {
                listItemLinks.Add(Next(urlHelper));
            }

            //last
            if (Options.DisplayLinkToLastPage == PagedListDisplayMode.Always || (Options.DisplayLinkToLastPage == PagedListDisplayMode.IfNeeded && lastPageToDisplay < List.PageCount))
            {
                listItemLinks.Add(Last(urlHelper));
            }

            if (listItemLinks.Any())
            {
                //append class to first item in list?
                if (!string.IsNullOrWhiteSpace(Options.ClassToApplyToFirstListItemInPager))
                {
                    listItemLinks.First().AddCssClass(Options.ClassToApplyToFirstListItemInPager);
                }

                //append class to last item in list?
                if (!string.IsNullOrWhiteSpace(Options.ClassToApplyToLastListItemInPager))
                {
                    listItemLinks.Last().AddCssClass(Options.ClassToApplyToLastListItemInPager);
                }

                //append classes to all list item links
                foreach (var li in listItemLinks)
                {
                    foreach (var c in Options.LiElementClasses ?? Enumerable.Empty<string>())
                    {
                        li.AddCssClass(c);
                    }
                }
            }

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            var ul = new TagBuilder("ul");

            foreach (var linkItem in listItemLinks)
            {
                ul.InnerHtml.AppendHtml(linkItem);
            }

            if (Options.UlElementClasses != null)
            {
                foreach (var cssClass in Options.UlElementClasses)
                {
                    ul.AddCssClass(cssClass);
                }
            }

            output.Content.AppendHtml(ul);
        }
    }
}