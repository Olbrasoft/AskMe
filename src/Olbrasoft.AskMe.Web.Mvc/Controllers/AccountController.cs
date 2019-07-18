﻿using System.Threading.Tasks;
using Olbrasoft.AskMe.Web.Mvc.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Olbrasoft.AskMe.Data.Base.Objects;
using Olbrasoft.AskMe.Web.Mvc;

namespace Olbrasoft.AskMe.Web.Mvc.Controllers {
    [Route("Account")]
    public class AccountController : Controller {
        private readonly SignInManager<ApplicationUser> signInManager;

        // Constructor

        public AccountController(SignInManager<ApplicationUser> signInManager) {
            this.signInManager = signInManager;
        }

        // Actions

        [Route("Login")]
        public IActionResult Login() => this.View();

        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl = "/") {
            if (this.ModelState.IsValid) {
                var result = await this.signInManager.PasswordSignInAsync(
                    model.UserName,
                    model.Password,
                    model.RememberMe,
                    lockoutOnFailure: false);

                if (result.Succeeded) {
                    return this.LocalRedirect(returnUrl);
                } else {
                    this.ModelState.AddModelError(string.Empty, "Přihlášení se nezdařilo");
                }
            }
            return this.View();
        }

        [Route("Logout")]
        public async Task<IActionResult> Logout() {
            await this.signInManager.SignOutAsync();
            return this.MessageView("Odhlášení", "Byli jste úspěšně odhlášeni");
        }

    }
}