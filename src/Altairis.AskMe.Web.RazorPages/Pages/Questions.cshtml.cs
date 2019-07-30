using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
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

        public X.PagedList.IPagedList<Data.Transfer.Objects.UnansweredQuestionDto> PagedData { get; set; }

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
        public InputModel Input { get; set; }

        // Input model

        public class InputModel
        {
            [Required(ErrorMessage = "Není zadána otázka"), MaxLength(500), DataType(DataType.MultilineText)]
            public string QuestionText { get; set; }

            [MaxLength(100)]
            public string DisplayName { get; set; }

            [MaxLength(100), DataType(DataType.EmailAddress, ErrorMessage = "Nesprávný formát e-mailové adresy")]
            public string EmailAddress { get; set; }

            public int CategoryId { get; set; }
        }

        // Handlers

        public async Task OnGetAsync(int pageNumber)
        {
            var pageInfo = new PageInfo(5, pageNumber);
            var unansweredQuestions = await _askFacade.GetUnansweredQuestionsAsync(pageInfo);
            PagedData = unansweredQuestions.AsPagedList(pageInfo);
        }

        public async Task<IActionResult> OnPostAsync(int pageNumber)
        {
            if (this.ModelState.IsValid)
            {
                // Create and save question entity
                var nq = new Question
                {
                    QuestionText = this.Input.QuestionText,
                    CategoryId = this.Input.CategoryId,
                    DisplayName = this.Input.DisplayName,
                    EmailAddress = this.Input.EmailAddress
                };
                await _askFacade.AddAsync(nq);

                // Redirect to list of questions
                return this.RedirectToPage(pageName: "Questions", pageHandler: null, routeValues: new { pageNumber = string.Empty }, fragment: $"q_{nq.Id}");
            }

            var pageInfo = new PageInfo(5, pageNumber);
            var unansweredQuestions = await _askFacade.GetUnansweredQuestionsAsync(pageInfo);
            PagedData = unansweredQuestions.AsPagedList(pageInfo);

            return Page();
        }
    }
}