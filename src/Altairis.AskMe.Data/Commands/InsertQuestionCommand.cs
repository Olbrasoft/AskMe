using Altairis.AskMe.Data.Base.Objects;
using Olbrasoft.Commanding;

namespace Altairis.AskMe.Data.Commands
{
    public class InsertQuestionCommand : Command<Question>
    {
        public InsertQuestionCommand(ICommandDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}