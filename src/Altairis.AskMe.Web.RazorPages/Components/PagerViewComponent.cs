using Altairis.AskMe.Web.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Altairis.AskMe.Web.RazorPages.Components {
    public class PagerViewComponent : ViewComponent {

        public IViewComponentResult Invoke(IPagedList model) => View(model);

    }
}
