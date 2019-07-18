using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Web.Mvc.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Altairis.AskMe.Web.Mvc.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        public AccountController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        private readonly SignInManager<ApplicationUser> _signInManager;

        // Actions

        [Route("Login")]
        public IActionResult Login() => View();

        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl = "/")
        {
            if (!ModelState.IsValid) return View();

            var result = await _signInManager.PasswordSignInAsync(
                model.UserName,
                model.Password,
                model.RememberMe,
                lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }

            ModelState.AddModelError(string.Empty, "Přihlášení se nezdařilo");
            return View();
        }

        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return this.MessageView("Odhlášení", "Byli jste úspěšně odhlášeni");
        }
    }
}