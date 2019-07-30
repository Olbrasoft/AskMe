using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Olbrasoft.AskMe.Business;
using Olbrasoft.Paging;
using Olbrasoft.Paging.X.PagedList;

namespace Altairis.AskMe.Web.RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IAsk _askFacade;

        public X.PagedList.IPagedList<Data.Transfer.Objects.QuestionDto> PagedData { get; set; }

        // Constructor
        public IndexModel(IAsk askFacade)
        {
            _askFacade = askFacade;
        }

        // Handlers
        public async Task OnGetAsync(int pageNumber)
        {
            var pageInfo = new PageInfo(10, pageNumber);
            var answeredQuestions = await _askFacade.GetAnsweredQuestionsAsync(pageInfo);
            PagedData = answeredQuestions.AsPagedList(pageInfo);
        }
    }
}