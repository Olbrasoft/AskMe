using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Altairis.AskMe.Data.Transfer.Objects;
using Microsoft.AspNetCore.Mvc.Rendering;
using Olbrasoft.Collections.Generic;

namespace Altairis.AskMe.Web.Mvc.Models.Home
{
    public class UnansweredQuestionsModel
    {
        public IEnumerable<SelectListItem> Categories { get; set; }

        public IPagedList<UnansweredQuestionDto> UnansweredQuestions { get; set; }


        public QuestionsModel.InputModel Input { get; set; }

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
    }
}