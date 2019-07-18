using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Olbrasoft.AskMe.Data.EntityFrameworkCore;

namespace Altairis.AskMe.Web.RazorPages.Pages.Admin {
    public class IndexModel : PageModel {
        private readonly AskDbContext dbContext;

        // Constructor

        public IndexModel(AskDbContext dbContext) {
            this.dbContext = dbContext;
        }

        // Model properties

        public IEnumerable<SelectListItem> Categories => this.dbContext.Categories
            .OrderBy(c => c.Name)
            .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });

        [BindProperty]
        public InputModel Input { get; set; }

        // Input model

        public class InputModel {
            [Required(ErrorMessage = "Nen� zad�na ot�zka"), MaxLength(500), DataType(DataType.MultilineText)]
            public string QuestionText { get; set; }

            public string AnswerText { get; set; }

            [MaxLength(100)]
            public string DisplayName { get; set; }

            [MaxLength(100), DataType(DataType.EmailAddress, ErrorMessage = "Nespr�vn� form�t e-mailov� adresy")]
            public string EmailAddress { get; set; }

            public int CategoryId { get; set; }
        }

        // Handlers

        public async Task<IActionResult> OnGetAsync(int questionId) {
            // Get question
            var q = await this.dbContext.Questions.FindAsync(questionId);
            if (q == null) return this.NotFound();

            // Prepare model
            this.Input = new InputModel {
                AnswerText = q.AnswerText,
                CategoryId = q.CategoryId,
                DisplayName = q.DisplayName,
                EmailAddress = q.EmailAddress,
                QuestionText = q.QuestionText
            };

            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync(int questionId) {
            // Get question
            var q = await this.dbContext.Questions.FindAsync(questionId);
            if (q == null) return this.NotFound();

            if (this.ModelState.IsValid) {
                // Update question
                q.CategoryId = this.Input.CategoryId;
                q.DisplayName = this.Input.DisplayName;
                q.EmailAddress = this.Input.EmailAddress;
                q.QuestionText = this.Input.QuestionText;

                if (string.IsNullOrWhiteSpace(this.Input.AnswerText)) {
                    q.AnswerText = null;
                    q.DateAnswered = null;
                }
                else {
                    q.AnswerText = this.Input.AnswerText;
                    if (!q.DateAnswered.HasValue) q.DateAnswered = DateTime.Now;
                }

                await this.dbContext.SaveChangesAsync();
                return this.RedirectToPage("/Question", new { questionId = q.Id });
            }
            return this.Page();
        }
    }
}