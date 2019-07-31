using System.Collections.Generic;
using Altairis.AskMe.Data.Transfer.Objects;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace Altairis.AskMe.Web.Mvc.Models.Home
{
    public class UnansweredQuestionsModel
    {
        public IEnumerable<SelectListItem> Categories { get; set; }

        public IPagedList<UnansweredQuestionDto> UnansweredQuestions { get; set; }

        public InputQuestionDto InputQuestion { get; set; }
    }
}