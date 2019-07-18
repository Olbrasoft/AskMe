using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Transfer.Objects;
using Olbrasoft.Data.Commanding;

namespace Altairis.AskMe.Data.Commands
{
    public class InsertQuestionCommand : Command<Question>
    {
        public InsertQuestionCommand(ICommandDispatcher dispatcher) : base(dispatcher)
        {
            
        }
    }
}