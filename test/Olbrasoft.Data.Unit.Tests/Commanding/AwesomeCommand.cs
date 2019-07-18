using Olbrasoft.Data.Commanding;

namespace Olbrasoft.Data.Unit.Tests.Commanding
{
    public class AwesomeCommand : Command<AwesomeData>
    {
        public AwesomeCommand(ICommandDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}