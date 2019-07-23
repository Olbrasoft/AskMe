using System.Collections.Generic;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Transfer.Objects;
using Olbrasoft.Pagination;

namespace Olbrasoft.AskMe.Business
{
    public interface IAsk
    {
        Task<IEnumerable<CategoryListItemDto>> GetCategoriesAsync();

        Task<QuestionDto> GetQuestionAsync(int questionId);

        Task<IResultWithTotalCount<QuestionDto>> GetAnsweredQuestionsAsync(IPageInfo pagingSettings);

        Task<IResultWithTotalCount<UnansweredQuestionDto>> GetUnansweredQuestionsAsync(IPageInfo pagingSettings);

        Task AddAsync(Question question);

        Task EditAsync(QuestionDto question, out bool notFound );

        Task<bool> ExistQuestionAsync(int questionId);
        
        
        //Task<IEnumerable<SyndicationQuestionDto>> GetSyndicationQuestionsAsync(int maxTake);
    }
}