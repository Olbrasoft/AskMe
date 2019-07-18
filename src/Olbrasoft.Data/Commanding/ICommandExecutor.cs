using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Commanding
{
    public interface ICommandExecutor
    {
        void Execute(ICommand command);

        Task ExecuteAsync(ICommand command, CancellationToken cancellationToken);
    }
}
