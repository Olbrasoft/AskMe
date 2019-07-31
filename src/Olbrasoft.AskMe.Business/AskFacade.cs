using System.Collections.Generic;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Transfer.Objects;
using Olbrasoft.Paging;

namespace Olbrasoft.AskMe.Business
{
    public class AskFacade : IAsk
    {
        protected readonly ICategories Categories;
        protected readonly IQuestions Questions;

        public AskFacade(ICategories categories, IQuestions questions)
        {
            Categories = categories;
            Questions = questions;
        }

        public Task<IEnumerable<CategoryListItemDto>> GetCategoriesAsync()
        {
            return Categories.GetAsync();
        }

        public Task<QuestionDto> GetQuestionAsync(int questionId)
        {
            return Questions.GetAsync(questionId);
        }

        public Task<IResultWithTotalCount<QuestionDto>> GetAnsweredQuestionsAsync(IPageInfo pagingSettings)
        {
            return Questions.GetAnsweredAsync(pagingSettings);
        }

        public Task<IResultWithTotalCount<UnansweredQuestionDto>> GetUnansweredQuestionsAsync(IPageInfo pagingSettings)
        {
            return Questions.GetUnansweredAsync(pagingSettings);
        }

     
        public Task AddAsync(InputQuestionDto question,out int questionId )
        {
            return Questions.AddAsync(question,out questionId);
        }

        public Task EditAsync(QuestionDto question, out bool  notFound)
        {

            return Questions.EditAsync(question,out notFound);
           
        }

        public Task<bool> ExistQuestionAsync(int questionId)
        {

            return Questions.ExistAsync(questionId);
            
        }



        //public Task<IEnumerable<SyndicationQuestionDto>> GetSyndicationQuestionsAsync(int maxTake)
        //{
        //    return Questions.GetSyndicationsAsync(maxTake);
        //}
    }
}