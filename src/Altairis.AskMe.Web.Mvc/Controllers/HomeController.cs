using System.Linq;
using System.Threading.Tasks;
using Altairis.AskMe.Web.Mvc.Models.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Olbrasoft.AskMe.Business;
using Olbrasoft.Paging;
using Olbrasoft.Paging.X.PagedList;

namespace Altairis.AskMe.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAsk _askFacade;

        // Constructor
        public HomeController(IAsk askFacade)
        {
            _askFacade = askFacade;
        }

        // Actions
        [Route("{pageNumber:int:min(1)=1}")]
        public async Task<IActionResult> Index(int pageNumber)
        {
            var pageInfo = new PageInfo(10, pageNumber);
            var answeredQuestions = await _askFacade.GetAnsweredQuestionsAsync(pageInfo);

            return View(answeredQuestions.AsPagedList(pageInfo));
        }

        [Route("Question/{questionId:int:min(1)}")]
        public async Task<IActionResult> Question(int questionId)
        {
            var model = await _askFacade.GetQuestionAsync(questionId);
            if (model == null) return NotFound();

            return View(model);
        }

        [Route("Questions/{pageNumber:int:min(1)=1}")]
        public async Task<IActionResult> Questions(int pageNumber)
        {
            var pageInfo = new PageInfo(5, pageNumber);

            var model = new UnansweredQuestionsModel
            {
                Categories = (await _askFacade.GetCategoriesAsync()).Select(c => new SelectListItem { Text = c.Text, Value = c.Value.ToString() }),
                UnansweredQuestions = (await _askFacade.GetUnansweredQuestionsAsync(pageInfo)).AsPagedList(pageInfo)
            };

            return View(model);
        }

        [HttpPost, Route("Questions/{pageNumber:int:min(1)=1}")]
        public async Task<IActionResult> Questions(int pageNumber, UnansweredQuestionsModel model)
        {
            // Validate posted data
            if (ModelState.IsValid)
            {
                await _askFacade.AddAsync(model.Input, out var id);

                // Redirect to list of questions
                return RedirectToAction(
                    actionName: "Questions",
                    controllerName: "Home",
                    routeValues: new { pageNumber = string.Empty },
                    fragment: $"q_{id}");
            }

            // Posted data not is valid
            var pageInfo = new PageInfo(5, pageNumber);

            model.Categories = (await _askFacade.GetCategoriesAsync()).Select(c => new SelectListItem { Text = c.Text, Value = c.Value.ToString() });
            model.UnansweredQuestions =
                (await _askFacade.GetUnansweredQuestionsAsync(pageInfo)).AsPagedList(pageInfo);

            return View(model);
        }

        [Route("Contact")]
        public IActionResult Contact() => View();
    }
}