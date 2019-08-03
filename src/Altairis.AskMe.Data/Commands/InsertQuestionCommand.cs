using Altairis.AskMe.Data.Transfer.Objects;
using Olbrasoft.Commanding;

namespace Altairis.AskMe.Data.Commands
{
    public class InsertQuestionCommand : Command<InputQuestionDto>
    {
        public InsertQuestionCommand(ICommandDispatcher dispatcher) : base(dispatcher)
        {
        }

        public int QuestionId { get; set; }
    }
}