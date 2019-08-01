using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using NHibernate;
using Olbrasoft.Mapping;
using Olbrasoft.Querying.Mapping.NHibernate;

namespace Olbrasoft.AskMe.Data.NHibernate.QueryHandlers
{
    public class SyndicationQuestionsQueryHandler : QueryHandlerWithMapperAndSessionFactory<SyndicationQuestionsQuery, IEnumerable<SyndicationQuestionDto>>
    {
        public SyndicationQuestionsQueryHandler(IMapper mapper, ISessionFactory factory) : base(mapper, factory)
        {
        }

        public override async Task<IEnumerable<SyndicationQuestionDto>> HandleAsync(SyndicationQuestionsQuery query, CancellationToken token)
        {
            var questions = await Session.QueryOver<Question>().Where(p => p.DateAnswered != null)
                .OrderBy(p => p.DateAnswered).Desc.Take(query.Take).ListAsync(token);

            return MapTo<IEnumerable<SyndicationQuestionDto>>(questions);
        }
    }
}