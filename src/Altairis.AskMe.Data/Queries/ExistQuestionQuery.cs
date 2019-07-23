using Olbrasoft.Querying;

namespace Altairis.AskMe.Data.Queries
{
    public class ExistQuestionQuery : Query<bool>
    {
        public ExistQuestionQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }

        public int QuestionId { get; set; }
    }
}