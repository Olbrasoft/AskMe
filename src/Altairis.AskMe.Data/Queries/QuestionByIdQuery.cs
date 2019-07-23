using Altairis.AskMe.Data.Transfer.Objects;
using Olbrasoft.Querying;

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