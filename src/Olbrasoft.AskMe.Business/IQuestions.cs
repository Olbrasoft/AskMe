using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Transfer.Objects;
using Olbrasoft.Pagination;

namespace Olbrasoft.AskMe.Business
{
    public interface IQuestions
    {
        Task<QuestionDto> GetAsync(int id, CancellationToken cancellationToken = default);

        Task<IResultWithTotalCount<QuestionDto>> GetAnsweredAsync(
            IPageInfo pagingSettings,
            CancellationToken cancellationToken = default
        );

        Task<IResultWithTotalCount<UnansweredQuestionDto>> GetUnansweredAsync(
            IPageInfo pagingSettings,
            CancellationToken cancellationToken = default
        );

        Task AddAsync(Question question, CancellationToken token = default);

        Task<IEnumerable<SyndicationQuestionDto>> GetSyndicationsAsync(int take, CancellationToken token = default);

        Task EditAsync(QuestionDto question, out bool notFound , CancellationToken token = default);

        Task<bool> ExistAsync(int id, CancellationToken token = default);
    }
}