using System.Collections.Generic;
using Altairis.AskMe.Data.Transfer.Objects;
using Olbrasoft.Data.Querying;

namespace Altairis.AskMe.Data.Queries
{
    public class SyndicationQuestionsQuery : Query<IEnumerable<SyndicationQuestionDto>>
    {
        public SyndicationQuestionsQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }

        public int Take { get; set; }
    }
}