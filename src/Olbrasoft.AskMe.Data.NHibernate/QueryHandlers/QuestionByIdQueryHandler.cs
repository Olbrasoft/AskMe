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
    public class QuestionByIdQueryHandler : QueryHandlerWithMapperAndSessionFactory<QuestionByIdQuery, QuestionDto>
    {
        public QuestionByIdQueryHandler(IMapper mapper, ISessionFactory factory) : base(mapper, factory)
        {
        }

        public override async Task<QuestionDto> HandleAsync(QuestionByIdQuery query, CancellationToken token)
        {
            var question = await Session.QueryOver<Question>().Where(p => p.Id == query.QuestionId)
                .SingleOrDefaultAsync(token);

            var result = MapTo<QuestionDto>(question);

            return result;
        }
    }
}