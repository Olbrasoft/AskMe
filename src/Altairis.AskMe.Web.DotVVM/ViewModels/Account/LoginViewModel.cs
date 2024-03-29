using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using DotVVM.Framework.ViewModel.Validation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace Altairis.AskMe.Web.DotVVM.ViewModels.Account {
    public class LoginViewModel : Altairis.AskMe.Web.DotVVM.ViewModels.MasterPageViewModel {
        private readonly SignInManager<ApplicationUser> signInManager;

        public LoginViewModel(SignInManager<ApplicationUser> signInManager, IHostingEnvironment env) : base(env) {
            this.signInManager = signInManager;
        }

        public InputModel Input { get; set; } = new InputModel();

        public override string PageTitle => "P�ihl�en�";

        public class InputModel {
            [Required]
            public string UserName { get; set; }

            [Required, DataType(DataType.Password)]
            public string Password { get; set; }

            public bool RememberMe { get; set; }
        }

        public async Task Login() {
            var result = await this.signInManager.PasswordSignInAsync(
                    this.Input.UserName,
                    this.Input.Password,
                    this.Input.RememberMe,
                    lockoutOnFailure: false);

            if (result.Succeeded) {
                var url = this.Context.Query.TryGetValue("returnUrl", out var x) ? x : "/";
                this.Context.RedirectToUrl(url);
            } else {
                //this.Context.ModelState.Errors.Add(new ViewModelValidationError { ErrorMessage = "P�ihl�en� se nezda�ilo" });
                this.AddModelError(x => x.Input, "P�ihl�en� se nezda�ilo");
                this.Context.FailOnInvalidModelState();
            }
        }
    }
}