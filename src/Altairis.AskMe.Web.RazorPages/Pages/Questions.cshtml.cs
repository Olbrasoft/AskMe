using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Transfer.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Olbrasoft.AskMe.Business;
using Olbrasoft.Paging;
using Olbrasoft.Paging.X.PagedList;

namespace Altairis.AskMe.Web.RazorPages.Pages
{
    public class QuestionsModel : PageModel
    {
        private readonly IAsk _askFacade;

        public X.PagedList.IPagedList<UnansweredQuestionDto> PagedData { get; set; }

        // Constructor
        public QuestionsModel(IAsk askFacade)
        {
            _askFacade = askFacade;
        }

        // Model properties
        public IEnumerable<SelectListItem> Categories => _askFacade.GetCategoriesAsync().Result.Select(c =>
            new SelectListItem
            {
                Text = c.Text,
                Value = c.Value.ToString()
            });

        [BindProperty]
        public InputQuestionDto InputQuestion { get; set; }
      

        // Handlers
        public async Task OnGetAsync(int pageNumber)
        {
            var pageInfo = new PageInfo(5, pageNumber);
            var unansweredQuestions = await _askFacade.GetUnansweredQuestionsAsync(pageInfo);
            PagedData = unansweredQuestions.AsPagedList(pageInfo);
        }

        public async Task<IActionResult> OnPostAsync(int pageNumber)
        {
            if (ModelState.IsValid)
            {
                await _askFacade.AddAsync(InputQuestion, out var id);

                // Redirect to list of questions
                return RedirectToPage(pageName: "Questions", pageHandler: null, routeValues: new { pageNumber = string.Empty }, fragment: $"q_{id}");
            }

            var pageInfo = new PageInfo(5, pageNumber);
            var unansweredQuestions = await _askFacade.GetUnansweredQuestionsAsync(pageInfo);
            PagedData = unansweredQuestions.AsPagedList(pageInfo);

            return Page();
        }
    }
}