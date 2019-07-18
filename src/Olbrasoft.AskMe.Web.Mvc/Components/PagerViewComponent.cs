using Olbrasoft.AskMe.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Olbrasoft.AskMe.Web.Mvc.Models;

namespace Olbrasoft.AskMe.Web.Mvc.Components {
    public class PagerViewComponent : ViewComponent {

        public IViewComponentResult Invoke(PagingInfo model) => this.View(model);

    }
}
