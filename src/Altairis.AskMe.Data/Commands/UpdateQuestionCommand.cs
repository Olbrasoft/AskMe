using Altairis.AskMe.Data.Transfer.Objects;
using Olbrasoft.Data.Commanding;

namespace Altairis.AskMe.Data.Commands
{
    public class UpdateQuestionCommand : Command<QuestionDto>
    {
        public UpdateQuestionCommand(ICommandDispatcher dispatcher) : base(dispatcher)
        {
        }

        public bool NotFound { get; set; } = false;
    }
}