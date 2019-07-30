using Altairis.AskMe.Data.Transfer.Objects;
using Olbrasoft.Commanding;

namespace Altairis.AskMe.Data.Commands
{
    public class InputQuestionCommand : Command<InputQuestionDto>
    {
        public InputQuestionCommand(ICommandDispatcher dispatcher) : base(dispatcher)
        {
        }

        public int QuestionId { get; set; }
    }
}