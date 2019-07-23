using Microsoft.AspNetCore.Mvc;

namespace Altairis.AskMe.Web.Mvc.Components {
    public class MenuViewComponent : ViewComponent {
        public IViewComponentResult Invoke()
        {
            return View(!User.Identity.IsAuthenticated ? "Anonymous" : "Authenticated");
        }
    }
}
