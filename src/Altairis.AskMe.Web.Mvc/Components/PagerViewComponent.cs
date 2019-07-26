using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Altairis.AskMe.Web.Mvc.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IPagedList model) => View(model);
    }
}