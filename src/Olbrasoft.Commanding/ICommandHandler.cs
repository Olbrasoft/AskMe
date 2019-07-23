using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Commanding
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void  Handle(TCommand command);

        Task HandleAsync(TCommand command, CancellationToken token);
        
    }
}