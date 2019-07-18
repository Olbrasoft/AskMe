using Altairis.AskMe.Data.Transfer.Objects;
using Olbrasoft.Data.Querying;

namespace Altairis.AskMe.Data.Queries
{
    public class QuestionByIdQuery : Query<QuestionDto>
    {
        public QuestionByIdQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }

        public int QuestionId { get; set; }
    }
}