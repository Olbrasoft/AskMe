using System.Linq;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Transfer.Objects;
using Altairis.AskMe.Web.Mvc.Models.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Olbrasoft.AskMe.Business;

namespace Altairis.AskMe.Web.Mvc.Controllers
{
    [Route("Admin"), Authorize]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        private readonly IAsk _askFacade;

        // Constructor
        public AdminController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IAsk askFacade)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _askFacade = askFacade;
        }

        // Actions
        [Route("{questionId:int:min(1)}")]
        public async Task<IActionResult> Index(int questionId)
        {
            // Get question
            var q = await _askFacade.GetQuestionAsync(questionId);
            if (q == null) return NotFound();

            // Prepare model
            var model = new IndexModel
            {
                AnswerText = q.AnswerText,
                CategoryId = q.CategoryId,
                DisplayName = q.DisplayName,
                EmailAddress = q.EmailAddress,
                QuestionText = q.QuestionText,
                Categories = (await _askFacade.GetCategoriesAsync()).Select(c => new SelectListItem { Text = c.Text, Value = c.Value.ToString() })
            };

            return View(model);
        }

        [HttpPost, Route("{questionId:int:min(1)}")]
        public async Task<IActionResult> Index(int questionId, IndexModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var question = new QuestionDto
            {
                Id = questionId,
                CategoryId = model.CategoryId,
                DisplayName = model.DisplayName,
                EmailAddress = model.EmailAddress,
                QuestionText = model.QuestionText,
                AnswerText = model.AnswerText
            };

            await _askFacade.EditAsync(question, out var notFound);

            if (notFound) return NotFound();

            return this.RedirectToAction(
                actionName: "Question",
                controllerName: "Home",
                routeValues: new { questionId = question.Id });
        }

        [Route("ChangePassword")]
        public IActionResult ChangePassword() => this.View();

        [HttpPost, Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (this.ModelState.IsValid)
            {
                // Get current user
                var user = await this.userManager.GetUserAsync(this.User);

                // Try to change password
                var result = await this.userManager.ChangePasswordAsync(
                    user,
                    model.OldPassword,
                    model.NewPassword);

                if (result.Succeeded)
                {
                    // OK, re-sign and redirect to homepage
                    await this.signInManager.SignInAsync(user, isPersistent: false);
                    return this.MessageView("Změna hesla", "Vaše heslo bylo úspěšně změněno.");
                }
                else
                {
                    // Failed - show why
                    foreach (var error in result.Errors)
                    {
                        this.ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return this.View(model);
        }
    }
}