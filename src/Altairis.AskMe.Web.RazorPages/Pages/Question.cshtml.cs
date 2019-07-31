using System.Threading.Tasks;
using Altairis.AskMe.Data.Transfer.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Olbrasoft.AskMe.Business;

namespace Altairis.AskMe.Web.RazorPages.Pages
{
    public class QuestionModel : PageModel
    {
        private readonly IQuestions _questions;

        // Constructor

        public QuestionModel(IQuestions questions)
        {
            _questions = questions;
        }

        // Model properties

        public QuestionDto Data { get; set; }

        // Handlers

        public async Task<IActionResult> OnGetAsync(int questionId)
        {
            Data = await _questions.GetAsync(questionId);
            return Data == null ? NotFound() : (IActionResult)Page();
        }
    }
}