using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Transfer.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Olbrasoft.AskMe.Business;

namespace Altairis.AskMe.Web.RazorPages.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly IAsk _askFacade;

        // Constructor

        public IndexModel(IAsk askFacade)
        {
            _askFacade = askFacade;
        }

        // Model properties

        public IEnumerable<SelectListItem> Categories => _askFacade.GetCategoriesAsync().Result.Select(
            c => new SelectListItem { Text = c.Text, Value = c.Value.ToString() });

        [BindProperty]
        public InputModel Input { get; set; }

        // Input model

        public class InputModel
        {
            [Required(ErrorMessage = "Není zadána otázka"), MaxLength(500), DataType(DataType.MultilineText)]
            public string QuestionText { get; set; }

            public string AnswerText { get; set; }

            [MaxLength(100)]
            public string DisplayName { get; set; }

            [MaxLength(100), DataType(DataType.EmailAddress, ErrorMessage = "Nesprávný formát e-mailové adresy")]
            public string EmailAddress { get; set; }

            public int CategoryId { get; set; }
        }

        // Handlers

        public async Task<IActionResult> OnGetAsync(int questionId)
        {
            // Create question
            var q = await _askFacade.GetQuestionAsync(questionId);
            if (q == null) return NotFound();

            // Prepare model
            Input = new InputModel
            {
                AnswerText = q.AnswerText,
                CategoryId = q.CategoryId,
                DisplayName = q.DisplayName,
                EmailAddress = q.EmailAddress,
                QuestionText = q.QuestionText
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int questionId)
        {
            // Create question

            if (!ModelState.IsValid) return Page();

            var question = new QuestionDto
            {
                Id = questionId,
                CategoryId = Input.CategoryId,
                DisplayName = Input.DisplayName,
                EmailAddress = Input.EmailAddress,
                QuestionText = Input.QuestionText,
                AnswerText = Input.AnswerText
            };

            await _askFacade.EditAsync(question, out var notFound);

            if (notFound) return NotFound();
            
            return RedirectToPage("/Question", new { questionId = question.Id });
        }
    }
}