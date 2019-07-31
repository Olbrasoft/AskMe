using System.Collections.Generic;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Transfer.Objects;
using Olbrasoft.Paging;

namespace Olbrasoft.AskMe.Business
{
    public interface IAsk
    {
        Task<IEnumerable<CategoryListItemDto>> GetCategoriesAsync();

        Task<QuestionDto> GetQuestionAsync(int questionId);

        Task<IResultWithTotalCount<QuestionDto>> GetAnsweredQuestionsAsync(IPageInfo pagingSettings);

        Task<IResultWithTotalCount<UnansweredQuestionDto>> GetUnansweredQuestionsAsync(IPageInfo pagingSettings);
        
        Task AddAsync(InputQuestionDto question,out int questionId);

        Task EditAsync(QuestionDto question, out bool notFound );

        Task<bool> ExistQuestionAsync(int questionId);
        
        
        //Task<IEnumerable<SyndicationQuestionDto>> GetSyndicationQuestionsAsync(int maxTake);
    }
}